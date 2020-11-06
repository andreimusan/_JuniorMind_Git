namespace RangeProblem
{
    public class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new SuccessMatch(pattern.Match(text).RemainingText());
        }
    }
}
