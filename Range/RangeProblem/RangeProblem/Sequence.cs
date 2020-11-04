namespace RangeProblem
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var remainingText = text;

            foreach (var pattern in patterns)
            {
                if (remainingText == null || !pattern.Match(remainingText).Success())
                {
                    return new FailedMatch(text);
                }

                remainingText = remainingText.Substring(1);
            }

            return new SuccessMatch(remainingText);
        }
    }
}
