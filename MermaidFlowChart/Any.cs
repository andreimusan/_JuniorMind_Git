using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Any : IPattern
    {
        private readonly string accepted;
        private string cutText = "";

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && accepted.Contains(text[0]))
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
