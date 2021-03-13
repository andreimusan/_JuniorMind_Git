using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class Program
    {
        public static void Main()
        {
            int[] ageArray = { 16, 18, 21, 25 };
            var readAgePosition = Console.ReadLine();

            try
            {
                int position = int.Parse(readAgePosition);
                Console.WriteLine($"Selected age position: {position}");

                try
                {
                    Console.WriteLine($"Age on selected position: {ageArray[position]}");
                    CheckAge(ageArray[position]);
                }
                catch (Exception e) when (e is IndexOutOfRangeException)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e) when (e is FormatException)
            {
                Console.WriteLine($"Unable to parse: {readAgePosition}");
                Console.WriteLine("Please repeat the test with a valid integer number.");
            }
            finally
            {
                Console.Read();
            }
        }

        static void CheckAge(int age)
        {
            int ageLimit = 18;
            if (age < ageLimit)
            {
                throw new ArithmeticException("Access denied - You do not meet the age eligibility; minimum age 18 years old.");
            }
            else
            {
                Console.WriteLine("Access granted - You meet the age eligibility.");
            }
        }
    }
}
