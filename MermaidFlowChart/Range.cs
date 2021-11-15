using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Range : IPattern
    {
        private readonly char start;
        private readonly char end;
        private readonly string exceptions;
        private string cutText = "";

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
                return new FailedMatch(text, cutText);
            }

            if (text[0] >= start && text[0] <= end && !exceptions.Contains(text[0]))
            {
                cutText = text[0].ToString();
                return new SuccessMatch(text.Substring(1), cutText);
            }

            cutText = "";
            return (IMatch)new FailedMatch(text, cutText);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
