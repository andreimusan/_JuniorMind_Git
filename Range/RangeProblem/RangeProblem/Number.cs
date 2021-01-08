namespace RangeProblem
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            // aici construiește patternul pentru
            // un JSON number
            var digit = new Range('0', '9', "");
            var digits = new OneOrMore(digit);
            var integer = new Sequence(new Optional(new Character('-')), new Choice(new Character('0'), digits));
            var fractionSymbol = new Character('.');
            var fraction = new Optional(new Sequence(fractionSymbol, digits));
            var exponentSymbol = new Any("eE");
            var sign = new Optional(new Any("+-"));
            var exponent = new Optional(new Sequence(exponentSymbol, sign, digits));

            pattern = new Sequence(integer, fraction, exponent);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
