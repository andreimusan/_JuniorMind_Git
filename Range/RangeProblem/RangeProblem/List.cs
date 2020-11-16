namespace RangeProblem
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Optional(new Choice(new OneOrMore(new Sequence(element, separator)), element));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
