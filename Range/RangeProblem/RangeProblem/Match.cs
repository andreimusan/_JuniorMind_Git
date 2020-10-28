using System;

namespace RangeProblem
{
    public class Match : IMatch
    {
        private readonly string text;

        public Match(string text)
        {
            this.text = text;
        }

        public bool Success()
        {
            return !string.IsNullOrEmpty(text);
        }

        public string RemainingText()
        {
            return text.Substring(1);
        }
    }
}
