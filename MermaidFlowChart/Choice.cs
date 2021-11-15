using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;
        private string cutText = "";

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);

                if (match.Success())
                {
                    cutText = match.CutText();
                    return match;
                }
            }

            cutText = "";
            return new FailedMatch(text, cutText);
        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[patterns.Length - 1] = pattern;
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
