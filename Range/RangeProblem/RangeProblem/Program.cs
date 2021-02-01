using System;

namespace RangeProblem
{
    public class Program
    {
        static void Main()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\andre\OneDrive\Documente\DOCS\_JuniorMind\JSON_file.txt");
            var value = new Value();
            var actual = value.Match(text);

            Console.WriteLine("The selected file is a valid JSON file? {0}", actual.Success());
            Console.Read();
        }
    }
}
