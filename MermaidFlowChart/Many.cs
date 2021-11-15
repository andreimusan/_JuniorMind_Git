using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        private string cutText = "";

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            cutText = "";
            IMatch match = new SuccessMatch(text, cutText);

            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
                cutText += match.CutText();
            }

            return new SuccessMatch(match.RemainingText(), cutText);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
