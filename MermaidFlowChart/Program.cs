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

            string fileName = Path.GetFileName(args[0]);
            string newFileExtension = Path.ChangeExtension(fileName, ".svg");

            string text2 = File.ReadAllText(args[0]);
            var elements = text2.Split(new[] { "\r\n", "\r", "\n", " -", "> " }, StringSplitOptions.RemoveEmptyEntries);
            var rectangles2 = new List<IFlowChartShape>();

            foreach (var elem in elements)
            {
                if (elem == "-")
                {
                    rectangles2.Add(new ArrowDown());
                }
                else
                {
                    rectangles2.Add(new RectangleNode(elem));
                }
            }

            rectangles2.ForEach(x => x.UpdateWidth());
            int maxLenghth = rectangles2.OrderBy(x => x.GetDimensions().width).Last().GetDimensions().width;
            int prevHeight = 0;
            string svg = "";
            int half = 2;

            foreach (var elem in rectangles2)
            {
                int currentHeight = elem.GetDimensions().height;
                (int, int) newCoordinates = (maxLenghth, prevHeight + (currentHeight / half));
                elem.UpdateCoordinates(newCoordinates);
                svg += elem.DrawShape();
                prevHeight += currentHeight;
            }

            string file = "<svg width = \"1000\" height = \"1000\" xmlns = \"http://www.w3.org/2000/svg\" xmlns:svg = \"http://www.w3.org/2000/svg\">" + svg + "</svg>";
            StreamWriter write = File.CreateText(@"test_diagrams\" + newFileExtension);
            write.Write(file);
            write.Close();
        }
    }
}
