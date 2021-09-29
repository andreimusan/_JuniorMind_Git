using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public class ReversePolishNotation
    {
        public static double PolishNotation(string operation)
        {
            if (operation == null)
            {
                return 0;
            }

            var operationArray = operation.Split(' ');

            var result = operationArray.Aggregate(
                    Enumerable.Empty<double>(), (operand, current) => double.TryParse(current, out var value) ?
                    operand.Append(value) :
                    operand.SkipLast(2).Append(OperationResult(operand.TakeLast(2), current))).First();

            return result;
        }

        private static double OperationResult(IEnumerable<double> numbers, string value)
        {
            double result = 0;

            var firstNumber = numbers.ElementAt(0);
            var secondNumber = numbers.ElementAt(1);

            result = value switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                "%" => firstNumber % secondNumber,
                _ => result
            };

            return result;
        }
    }
}
