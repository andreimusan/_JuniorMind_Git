namespace RangeProblem
{
    public class Any : IPattern
    {
        private readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            foreach (var character in accepted)
            {
                if (!string.IsNullOrEmpty(text) && character == text[0])
                {
                    return new SuccessMatch(text.Substring(1));
                }
            }

            return new FailedMatch(text);
        }
    }
}
