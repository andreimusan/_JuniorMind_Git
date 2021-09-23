using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public class IntOperations
    {
        private readonly int[] array;
        private readonly int number;
        private readonly int sum;
        private readonly IEnumerable<int> newArray;

        public IntOperations(int[] array, int sum = 0, int number = 0)
        {
            this.array = array;
            this.newArray = array;
            this.number = number;
            this.sum = sum;
        }

        public IEnumerable<int[]> GenerateSubArraysWithSumLessThanNumber()
        {
            var result = Enumerable.Range(0, array.Length).
                SelectMany(i => Enumerable.Range(1, array.Length - i), (i, j) => array.Skip(i).Take(j)).
                Where(s => s.Sum() <= sum).
                Select(s => s.ToArray());

            return result;
        }

        public IEnumerable<int[]> GenerateCombinationsWithSumEqualToNumber()
        {
            var numberOfOptions = (int)Math.Pow(2, number);
            var numbersToString = Enumerable.Range(1, array.Length).Select(i => Convert.ToString(i, 10)).Aggregate((i, j) => i + j);
            var binaryNumbers = Enumerable.Range(0, numberOfOptions).Select(i => Convert.ToString(i, 2).PadLeft(array.Length, '0'));
            var signCombinations = binaryNumbers.Select(i => i.Select(sign => sign == '0' ? "-" : "+").Aggregate((i, j) => i + j));
            var numbersWithSigns = signCombinations.Select(i => i.Zip(numbersToString, (first, second) => first.ToString() + second.ToString()).Select(j => int.Parse(j)));
            var result = numbersWithSigns.Where(i => i.Sum() == sum).Select(i => i.ToArray());

            return result;
        }

        public IEnumerable<int[]> GeneratePythagoreanTriples()
        {
            var result = Enumerable.Range(0, array.Length).
                SelectMany(i => Enumerable.Range(0, array.Length).
                SelectMany(j => Enumerable.Range(0, array.Length).
                Where(k => array[i] * array[i] + array[j] * array[j] == array[k] * array[k]).
                Select(k => new[] { array[i], array[j], array[k] })));

            return result;
        }
    }
}
