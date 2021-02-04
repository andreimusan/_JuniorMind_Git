using System;
using System.IO;

namespace RangeProblem
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
            var value = new Value();
            var actual = value.Match(text);

            Console.WriteLine(actual.Success() && actual.RemainingText() == "" ? "TRUE - The selected file is a valid JSON file." : "FALSE - The selected file is NOT a valid JSON file.");
            Console.Read();
        }
    }
}
