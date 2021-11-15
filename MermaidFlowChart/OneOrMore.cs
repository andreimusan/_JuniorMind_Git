using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;
        private string cutText = "";

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern, new Many(pattern));
        }

        public IMatch Match(string text)
        {
            cutText += pattern.CutText();
            return pattern.Match(text);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
