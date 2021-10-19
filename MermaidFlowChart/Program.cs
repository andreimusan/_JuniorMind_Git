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
                    rectangles2.Add(new ArrowLeft());
                }
                else
                {
                    rectangles2.Add(new TrapezoidNode(elem));
                }
            }

            rectangles2.ForEach(x => x.UpdateDimensions());
            int maxHeight = rectangles2.OrderBy(x => x.GetDimensions().height).Last().GetDimensions().height;
            int prevWidth = 20;
            string svg = "";
            int half = 2;

            foreach (var elem in rectangles2)
            {
                int currentWidth = elem.GetDimensions().width;
                (int, int) newCoordinates = (prevWidth + (currentWidth / half), maxHeight);
                elem.UpdateCoordinates(newCoordinates);
                svg += elem.DrawShape();
                prevWidth += currentWidth;
            }

            var fileLocation = args.Length > 1 ? args[1] : "test_diagrams";

            string file = "<svg width = \"1000\" height = \"1000\" xmlns = \"http://www.w3.org/2000/svg\" xmlns:svg = \"http://www.w3.org/2000/svg\">" + svg + "</svg>";
            StreamWriter write = File.CreateText(fileLocation + "\\" + newFileExtension);
            write.Write(file);
            write.Close();
        }
    }
}
