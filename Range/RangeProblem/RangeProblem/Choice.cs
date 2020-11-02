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
            if (text == null)
            {
                return new FailedMatch(text);
            }

            foreach (var pattern in patterns)
            {
                if (text.Length > 1 && pattern.Match(text).RemainingText() == new SuccessMatch(text.Substring(1)).RemainingText())
                {
                    return new SuccessMatch(text);
                }
            }

            return new FailedMatch(text);
        }
    }
}
