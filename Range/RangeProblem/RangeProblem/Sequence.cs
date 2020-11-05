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
                var match = pattern.Match(remainingText);

                if (!match.Success())
                {
                    return new FailedMatch(text);
                }

                remainingText = match.RemainingText();
            }

            return new SuccessMatch(remainingText);
        }
    }
}
