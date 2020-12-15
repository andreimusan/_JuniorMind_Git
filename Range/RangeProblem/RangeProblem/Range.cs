using System;

namespace RangeProblem
{
    public class Range : IPattern
    {
        private readonly char start;
        private readonly char end;
        private readonly string exceptions;

        public Range(char start, char end, string exceptions = "")
        {
            this.start = start;
            this.end = end;
            this.exceptions = exceptions;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            return text[0] >= start && text[0] <= end && !exceptions.Contains(text[0])
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}
