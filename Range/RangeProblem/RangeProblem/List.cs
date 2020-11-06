namespace RangeProblem
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            this.pattern = new Many(new Choice(new Sequence(new Choice(element, separator), element), element));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
