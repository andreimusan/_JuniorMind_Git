using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public interface IPattern
    {
        IMatch Match(string text);

        string CutText();
    }
}
