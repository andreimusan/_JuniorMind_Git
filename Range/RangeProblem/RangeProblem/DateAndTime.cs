using System;

namespace RangeProblem
{
    public class DateAndTime : IPattern
    {
        private readonly IPattern pattern;

        public DateAndTime()
        {
            var openBracket = new Character('(');
            var closeBracket = new Character(')');

            var wsp = new Any(" \t");
            var crlf = new Any("\r\n");
            var fws = new Sequence(new Optional(new Sequence(wsp, crlf)), new OneOrMore(wsp));
            var vchar = new Range(Convert.ToChar(0x21), Convert.ToChar(0x7E));
            var quotedPair = new Sequence(new Character('\\'), new Choice(vchar, wsp));
            var ctext = new Choice(new Range(Convert.ToChar(33), Convert.ToChar(126), "()\\"));
            var ccontent = new Choice(ctext, quotedPair);
            var comment = new Sequence(openBracket, new Many(fws), ccontent, new Optional(fws), closeBracket);
            ccontent.Add(comment);
            var cfws = new Choice(new Sequence(openBracket, new Optional(fws), comment, new Optional(fws), closeBracket), fws);

            var secOrMinOrH = new Sequence(new Range('0', '9'), new Range('0', '9'));
            var timeOfDayShort = new Sequence(secOrMinOrH, new Character(':'), secOrMinOrH);
            var timeOfDayLong = new Sequence(secOrMinOrH, new Character(':'), secOrMinOrH, new Character(':'), secOrMinOrH);

            var sign = new Any("+-");
            var zone = new Sequence(fws, sign, secOrMinOrH, secOrMinOrH);

            var time = new Sequence(new Choice(timeOfDayLong, timeOfDayShort), zone);

            var year = new Sequence(fws, new Range('0', '9'), new Range('0', '9'), new Range('0', '9'), new Range('0', '9'), fws);

            var oddMonth = new Choice(new Text("Jan"), new Text("Mar"), new Text("May"), new Text("Jul"), new Text("Aug"), new Text("Oct"), new Text("Dec"));
            var evenMonth = new Choice(new Text("Feb"), new Text("Apr"), new Text("Jun"), new Text("Sep"), new Text("Nov"));

            var day = new Sequence(new Optional(fws), new Range('0', '9'), new Range('0', '9'), fws);

            var date = new Sequence(day, new Choice(oddMonth, evenMonth), year);

            var dayName = new Choice(new Text("Mon"), new Text("Tue"), new Text("Wed"), new Text("Thu"), new Text("Fri"), new Text("Sat"), new Text("Sun"));
            var dayOfWeek = new Sequence(new Optional(fws), dayName);

            var dateTime = new Choice(new Sequence(dayOfWeek, new Character(','), date, time, new Optional(cfws)), new Sequence(date, time, new Optional(cfws)));

            pattern = new Choice(new Sequence(dayOfWeek, new Character(','), date, time, new Optional(cfws)), new Sequence(date, time, new Optional(cfws)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
