namespace RangeProblem
{
    public class Number
    {
        private readonly IPattern pattern;

        public Number()
        {
            // aici construiește patternul pentru
            // un JSON number
            var digits = new OneOrMore(new Range('1', '9'));
            var zero = new OneOrMore(new Character('0'));
            var sign = new OneOrMore(new Any("+-"));
            var fraction = new Character('.');
            var exponent = new Optional(new Any("eE"));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Choice(sign, fraction, exponent);

            pattern = new Choice(zero, new Sequence(sign, zero), new OneOrMore(new Choice(new Sequence(digits, zero), digits, sign)), new Sequence(new OneOrMore(digits), fraction, new OneOrMore(digits)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
