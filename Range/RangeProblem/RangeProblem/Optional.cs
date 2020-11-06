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
            IMatch match = new SuccessMatch(text);

            return new SuccessMatch(pattern.Match(match.RemainingText()).RemainingText());
        }
    }
}
