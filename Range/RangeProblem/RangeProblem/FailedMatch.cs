namespace RangeProblem
{
    public class FailedMatch : IMatch
    {
        private readonly string remainingText;

        public FailedMatch(string remainingText)
        {
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return false;
        }

        public string RemainingText()
        {
            return remainingText;
        }
    }
}
