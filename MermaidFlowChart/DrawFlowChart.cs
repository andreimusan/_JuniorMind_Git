using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MermaidFlowChart
{
    public class DrawFlowChart
    {
        private readonly IFlowChartOrientation orientation;

        public DrawFlowChart(string textInput)
        {
            var text = File.ReadLines(textInput).ToList();
            orientation = SetOrientation(text);
        }

        public string Draw()
        {
            return orientation.Draw();
        }

        private IFlowChartOrientation SetOrientation(List<string> text)
        {
            var flowchartGenerator = new[] { "flowchart", "graph", "subgraph" };
            string newOrientation = "TB";

            foreach (var elem in flowchartGenerator)
            {
                if (text[0].Contains(elem))
                {
                    newOrientation = text[0].Substring(text[0].Length - 1 - 1, 1 + 1);
                    text.RemoveAt(0);
                }
            }

            return newOrientation switch
            {
                "BT" => new OrientationBT(text),
                "LR" => new OrientationLR(text),
                "RL" => new OrientationRL(text),
                _ => new OrientationTB(text),
            };
        }
    }
}
