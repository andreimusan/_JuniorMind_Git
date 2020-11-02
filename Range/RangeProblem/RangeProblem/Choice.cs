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
                if (text != null && pattern.Match(text).Success())
                {
                    return new SuccessMatch(text.Substring(1));
                }
            }

            return new FailedMatch(text);
        }
    }
}
