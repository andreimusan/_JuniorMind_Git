namespace RangeProblem
{
    public class SuccessMatch : IMatch
    {
        private readonly string remainingText;

        public SuccessMatch(string remainingText)
        {
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return true;
        }

        public string RemainingText()
        {
            return remainingText;
        }
    }
}
