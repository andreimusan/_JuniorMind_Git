namespace RangeProblem
{
    public class Number
    {
        private readonly IPattern pattern;

        public Number()
        {
            // aici construiește patternul pentru
            // un JSON number
            var oneNine = new Range('1', '9');
            var digit = new Choice(new Character('0'), oneNine);
            var digits = new OneOrMore(digit);
            var sign = new Optional(new Any("+-"));
            var integer = new Choice(new Sequence(sign, digit), new Sequence(sign, oneNine, digits));
            var fractionSymbol = new Character('.');
            var fraction = new Sequence(fractionSymbol, digits);
            var exponentSymbol = new Any("eE");
            var exponent = new Sequence(exponentSymbol, sign, digits);

            pattern = new OneOrMore(new Choice(integer, fraction, exponent));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
