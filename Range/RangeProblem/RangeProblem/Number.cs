namespace RangeProblem
{
    public class Number
    {
        private readonly IPattern pattern;

        public Number()
        {
            // aici construiește patternul pentru
            // un JSON number
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var digits = new OneOrMore(digit);
            var sign = new Any("+-");
            var integer = new Sequence(new Optional(sign), digits);
            var fractionSymbol = new Character('.');
            var fraction = new Sequence(fractionSymbol, digits);
            var exponentSymbol = new Any("eE");
            var exponent = new Sequence(exponentSymbol, new Optional(sign), digits);

            pattern = new OneOrMore(new Choice(integer, fraction, exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
