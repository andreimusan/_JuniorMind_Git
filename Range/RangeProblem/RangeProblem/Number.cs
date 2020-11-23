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
            var exponent = new Any("eE");
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Choice(sign, fraction, exponent);

            var minusZero = new Sequence(sign, zero);
            var intNumber = new OneOrMore(new Choice(new Sequence(digits, zero), digits, sign));
            var factionalNumber = new Sequence(new OneOrMore(digits), fraction, new OneOrMore(digits));
            var numberWithExponent = new Sequence(new OneOrMore(digits), exponent, new OneOrMore(digits));
            var numberWithPosOrNegExponent = new Sequence(new OneOrMore(digits), exponent, sign, new OneOrMore(digits));
            var factionalNumberWithExponent = new Sequence(new OneOrMore(digits), fraction, new OneOrMore(digits), exponent, new OneOrMore(digits));
            var factionalNumberWithPosOrNegExponent = new Sequence(new OneOrMore(digits), fraction, new OneOrMore(digits), exponent, sign, new OneOrMore(digits));

            pattern = new Choice(zero, minusZero, factionalNumberWithExponent, factionalNumberWithPosOrNegExponent, factionalNumber, numberWithExponent, numberWithPosOrNegExponent, intNumber);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
