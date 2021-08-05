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
        private IEnumerable<int> newArray;

        public IntOperations(int[] array, int sum, int number = 0)
        {
            this.array = array;
            this.number = number;
            this.sum = sum;
        }

        public IEnumerable GenerateSubArraysWithSumLessThanNumber()
        {
            var result = from i in Enumerable.Range(0, array.Length)
                         from j in Enumerable.Range(1, array.Length - i)
                         let subarray = array.Skip(i).Take(j)
                         orderby subarray.Count()
                         where subarray.Sum() <= sum
                         select subarray.ToList();

            return result;
        }

        public IEnumerable GenerateCombinationsWithSumEqualToNumber()
        {
            int[] zero = { 0 };
            newArray = Enumerable.Range(-number, number).Except(zero);
            var result = this.GenerateCombinations().Where(value => value.Sum() == sum).ToList();

            return result;
        }

        public IEnumerable<IEnumerable<int>> GenerateCombinations()
        {
            if (!newArray.Any())
            {
                return Enumerable.Repeat(Enumerable.Empty<int>(), 1);
            }

            var firstElement = newArray.Take(1);
            var remainingElements = GenerateCombinations(newArray.Skip(1));
            var subArray = remainingElements.Select(elem => firstElement.Concat(elem));
            var result = subArray.Concat(remainingElements);

            return result;
        }

        private IEnumerable<IEnumerable<int>> GenerateCombinations(IEnumerable<int> newArray)
        {
            if (!newArray.Any())
            {
                return Enumerable.Repeat(Enumerable.Empty<int>(), 1);
            }

            var firstElement = newArray.Take(1);
            var remainingElements = GenerateCombinations(newArray.Skip(1));
            var subArray = remainingElements.Select(elem => firstElement.Concat(elem));
            var result = subArray.Concat(remainingElements);

            return result;
        }
    }
}
