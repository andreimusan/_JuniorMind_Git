using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class CharacterText : IPattern
    {
        private readonly string prefix;
        private string cutText = "";

        public CharacterText(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (text?.StartsWith(prefix) == true)
            {
                cutText = prefix;
                return new SuccessMatch(text.Substring(prefix.Length), cutText);
            }

            return (IMatch)new FailedMatch(text, cutText);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
