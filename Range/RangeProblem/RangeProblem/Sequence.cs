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
            var initialText = text;

            foreach (var pattern in patterns)
            {
                if (!pattern.Match(text).Success())
                {
                    return new FailedMatch(initialText);
                }

                text = pattern.Match(text).RemainingText();
            }

            return new SuccessMatch(text);
        }
    }
}
