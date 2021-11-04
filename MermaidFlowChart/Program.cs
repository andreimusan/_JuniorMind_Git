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

            var flowchart = new DrawFlowChart(args[0]);
            string svg = flowchart.Draw();

            var fileLocation = args.Length > 1 ? args[1] : "test_diagrams";

            string file = "<svg width = \"1000\" height = \"1000\" xmlns = \"http://www.w3.org/2000/svg\" xmlns:svg = \"http://www.w3.org/2000/svg\">" + svg + "</svg>";
            StreamWriter write = File.CreateText(fileLocation + "\\" + newFileExtension);
            write.Write(file);
            write.Close();
        }
    }
}
