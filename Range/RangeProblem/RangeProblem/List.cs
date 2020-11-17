namespace RangeProblem
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Optional(new Choice(new Sequence(element, new OneOrMore(new Sequence(separator, element))), element));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
