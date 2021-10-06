using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MermaidFlowChart
{
    class Program
    {
        static void Main()
        {
            var rectangles = new List<IFlowChartShape>
            {
                new RectangleNode("Tastez"),
                new RectangleNode("Scriu"),
                new RectangleNode("Multe cuvinte lungi"),
                new RectangleNode("Eu"),
            };

            rectangles.ForEach(x => x.UpdateWidth());
            int maxLenghth = rectangles.OrderBy(x => x.GetDimensions().width).Last().GetDimensions().width;
            int prevHeight = 0;
            string svg = "";

            foreach (var elem in rectangles)
            {
                int currentHeight = elem.GetDimensions().height;
                (int, int) newCoordinates = (maxLenghth, prevHeight + currentHeight);
                elem.UpdateCoordinates(newCoordinates);
                svg += elem.DrawShape();
                prevHeight += currentHeight;
            }

            string file = "<svg width = \"1000\" height = \"1000\" xmlns = \"http://www.w3.org/2000/svg\" xmlns:svg = \"http://www.w3.org/2000/svg\">" +
                          svg +
                          "</svg>";
            StreamWriter write = File.CreateText(@"drawing.svg");
            write.Write(file);
            write.Close();
        }
    }
}
