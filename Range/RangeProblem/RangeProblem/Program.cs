using System;

namespace RangeProblem
{
    public class Range
    {
        private readonly char start;
        private readonly char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] < start || text[i] > end)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
