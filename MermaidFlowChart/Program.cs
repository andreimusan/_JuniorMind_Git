using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MermaidFlowChart
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Error: please specify the file to read!");
                Console.ReadKey();
                return;
            }

            string text = File.ReadAllText(args[0]);
            var lines = text.Split("\n\r".ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var rectangles = new List<IFlowChartShape>();
            Array.ForEach(lines, x => rectangles.Add(new RectangleNode(x)));

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

            string file = "<svg width = \"1000\" height = \"1000\" xmlns = \"http://www.w3.org/2000/svg\" xmlns:svg = \"http://www.w3.org/2000/svg\">" + svg + "</svg>";
            StreamWriter write = File.CreateText(@"test_diagrams\drawing.svg");
            write.Write(file);
            write.Close();
        }
    }
}
