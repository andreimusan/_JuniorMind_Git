using System;

namespace RangeProblem
{
    public class DateAndTime : IPattern
    {
        private readonly IPattern pattern;

        public DateAndTime()
        {
            var minuteOrSecond = new Sequence(new Range('0', '5'), new Range('0', '9'));
            var hour = new Choice(new Sequence(new Range('0', '1'), new Range('0', '9')), new Sequence(new Character('2'), new Range('0', '3')));
            var timeOfDayShort = new Sequence(hour, new Character(':'), minuteOrSecond);
            var timeOfDayLong = new Sequence(hour, new Character(':'), minuteOrSecond, new Character(':'), minuteOrSecond);
            var leapSecond = new Text("23:59:60");

            var openBracket = new Character('(');
            var closeBracket = new Character(')');

            var wsp = new Many(new Any(" \t"));
            var crlf = new Many(new Any("\r\n"));
            var fws = new Sequence(wsp, crlf, wsp);
            var ctext = new Choice(new Range(Convert.ToChar(33), Convert.ToChar(126), "()\\"));
            var ccontent = new Choice(ctext, new Sequence(new Character('"'), new Character('"')));
            var comment = new Sequence(openBracket, openBracket, fws, ccontent, closeBracket, fws, closeBracket);
            ccontent.Add(comment);
            var cfws = new Choice(new Sequence(openBracket, openBracket, fws, comment, closeBracket, fws, closeBracket), fws);

            var sign = new Any("+-");
            var zone = new Sequence(openBracket, fws, openBracket, sign, closeBracket, hour, minuteOrSecond, closeBracket);

            var time = new Sequence(new Choice(leapSecond, timeOfDayLong, timeOfDayShort), zone);

            var yearBefore2000 = new Sequence(new Character('1'), new Character('9'), new Range('0', '9'), new Range('0', '9'));
            var yearOver2000 = new Sequence(new Range('2', '9'), new Range('0', '9'), new Range('0', '9'), new Range('0', '9'));
            var leapBef2000Opt1 = new Sequence(new Character('1'), new Character('9'), new Any("02468"), new Any("48"));
            var leapBef2000Opt2 = new Sequence(new Character('1'), new Character('9'), new Any("13579"), new Any("26"));
            var leapOver2000Opt1 = new Sequence(new Range('2', '9'), new Range('0', '9'), new Any("02468"), new Any("48"));
            var leapOver2000Opt2 = new Sequence(new Range('2', '9'), new Range('0', '9'), new Any("13579"), new Any("26"));
            var leapOver2000Opt3 = new Sequence(new Range('2', '9'), new Range('0', '9'), new Any("2468"), new Character('0'));
            var leapOver2000Opt4 = new Sequence(new Any("2468"), new Any("48"), new Character('0'), new Character('0'));
            var leapOver2000Opt5 = new Sequence(new Any("3579"), new Any("26"), new Character('0'), new Character('0'));
            var leapOver2000Opt6 = new Sequence(new Any("248"), new Character('0'), new Character('0'), new Character('0'));
            var leapYearChoice = new Choice(leapBef2000Opt1, leapBef2000Opt2, leapOver2000Opt1, leapOver2000Opt2, leapOver2000Opt3, leapOver2000Opt4, leapOver2000Opt5, leapOver2000Opt6);

            var leapYear = new Sequence(openBracket, fws, leapYearChoice, fws, closeBracket);
            var year = new Sequence(openBracket, fws, new Choice(yearBefore2000, yearOver2000), fws, closeBracket);

            var oddMonth = new Choice(new Text("Jan"), new Text("Mar"), new Text("May"), new Text("Jul"), new Text("Aug"), new Text("Oct"), new Text("Dec"));
            var evenMonth = new Choice(new Text("Apr"), new Text("Jun"), new Text("Sep"), new Text("Nov"));
            var febMonth = new Text("Feb");
            var dayOddMonth = new Choice(new Sequence(new Character('3'), new Range('0', '1')), new Sequence(new Range('1', '2'), new Range('0', '9')), new Range('1', '9'));
            var dayEvenMonth = new Choice(new Text("30"), new Sequence(new Range('1', '2'), new Range('0', '9')), new Range('1', '9'));
            var dayFebMonth = new Choice(new Sequence(new Character('2'), new Range('0', '8')),  new Sequence(new Character('1'), new Range('0', '9')), new Range('1', '9'));
            var dayFebMonthLeapYear = new Choice(new Sequence(new Character('2'), new Range('0', '9')), new Sequence(new Character('1'), new Range('0', '9')), new Range('1', '9'));
            var dayOddSeq = new Sequence(openBracket, fws, dayOddMonth, fws, closeBracket);
            var dayEvenSeq = new Sequence(openBracket, fws, dayEvenMonth, fws, closeBracket);
            var dayFebSeq = new Sequence(openBracket, fws, dayFebMonth, fws, closeBracket);
            var dayFebLeapYearSeq = new Sequence(openBracket, fws, dayFebMonthLeapYear, fws, closeBracket);

            var dateFromatOddMonths = new Sequence(dayOddSeq, oddMonth, year);
            var dateFormatEvenMonths = new Sequence(dayEvenSeq, evenMonth, year);
            var dateFormatFebMonth = new Sequence(dayFebSeq, febMonth, year);
            var dateFormatFebMonthLeapYear = new Sequence(dayFebLeapYearSeq, febMonth, leapYear);
            var date = new Choice(dateFormatFebMonthLeapYear, dateFormatFebMonth, dateFormatEvenMonths, dateFromatOddMonths);

            var dayName = new Choice(new Text("Mon"), new Text("Tue"), new Text("Wed"), new Text("Thu"), new Text("Fri"), new Text("Sat"), new Text("Sun"));
            var dayOfWeek = new Sequence(openBracket, fws, dayName, closeBracket);

            var dateTime = new Choice(new Sequence(dayOfWeek, new Character(','), date, time, new Optional(cfws)), new Sequence(date, time, new Optional(cfws)));

            pattern = new Choice(new Sequence(dayOfWeek, new Character(','), date, time, new Optional(cfws)), new Sequence(date, time, new Optional(cfws)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
