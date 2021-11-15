using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Character : IPattern
    {
        private readonly char character;
        private string cutText = "";

        public Character(char character)
        {
            this.character = character;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && text[0] == character)
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
