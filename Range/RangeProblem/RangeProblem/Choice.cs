namespace RangeProblem
{
    public class Choice : IPattern
    {
        private readonly IPattern[] digitPatterns;

        public Choice(params IPattern[] patterns)
        {
            this.digitPatterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in digitPatterns)
            {
                if (pattern.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
