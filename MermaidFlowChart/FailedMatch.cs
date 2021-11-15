using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class FailedMatch : IMatch
    {
        private readonly string remainingText;
        private readonly string cutText;

        public FailedMatch(string remainingText, string cutText)
        {
            this.remainingText = remainingText;
            this.cutText = cutText;
        }

        public bool Success()
        {
            return false;
        }

        public string RemainingText()
        {
            return remainingText;
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
