namespace RangeProblem
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return text?.Contains(prefix) == true && text.IndexOf(prefix) == 0
                ? new SuccessMatch(text.Substring(prefix.Length))
                : (IMatch)new FailedMatch(text);
        }
    }
}
