using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;
        private string cutText = "";

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            cutText = "";
            IMatch match = new SuccessMatch(text, cutText);

            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                cutText += match.CutText();

                if (!match.Success())
                {
                    cutText = "";
                    return new FailedMatch(text, cutText);
                }
            }

            return new SuccessMatch(match.RemainingText(), cutText);
        }

        public string CutText()
        {
            return cutText;
        }
    }
}
