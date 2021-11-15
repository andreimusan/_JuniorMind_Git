using System;
using System.Collections.Generic;
using System.Text;

namespace MermaidFlowChart
{
    public interface IMatch
    {
        bool Success();

        string RemainingText();

        string CutText();
    }
}
