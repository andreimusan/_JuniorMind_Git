using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class SuccessMatch : IMatch
    {
        private readonly string remainingText;
        private readonly string cutText;

        public SuccessMatch(string remainingText, string cutText)
        {
            this.remainingText = remainingText;
            this.cutText = cutText;
        }

        public bool Success()
        {
            return true;
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
