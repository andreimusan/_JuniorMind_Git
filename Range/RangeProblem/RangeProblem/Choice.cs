namespace RangeProblem
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text) == new SuccessMatch(text))
                {
                    return new SuccessMatch(text);
                }
            }

            return new FailedMatch(text);
        }
    }
}
