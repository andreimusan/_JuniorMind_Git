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
                OrderBy(s => s.Count()).
                Where(s => s.Sum() <= sum).
                Select(s => s.ToArray());

            return result;
        }

        public IEnumerable<int[]> GenerateCombinationsWithSumEqualToNumber()
        {
            var negativeAndPositive = new[] { -1, 1 };
            var numberOfCombinations = (int)Math.Pow(2, number);
            const int two = 2;

            var result = Enumerable.Range(1, numberOfCombinations).
                Select(i => Enumerable.Range(1, number).
                        Select(j => negativeAndPositive[((i * j) / numberOfCombinations) % two] * j)).
                Where(value => value.Sum() == sum).
                Select(x => x.ToArray());

            return result;
        }

        public IEnumerable<IEnumerable<int>> GeneratePythagoreanTriples()
        {
            var combinationsOf3 = this.GenerateCombinations().Where(value => value.ToList().Count == 3).ToList();
            var permutations = new List<List<int>>();

            foreach (var list in combinationsOf3)
            {
                var permutate = GeneratePermutations(list.ToList(), list.ToList().Count);
                foreach (var p in permutate)
                {
                    if (IsPythagoreanTriples(p.ToList()))
                    {
                        permutations.Add(p.ToList());
                    }
                }
            }

            return permutations;
        }

        public IEnumerable<IEnumerable<int>> GeneratePermutations(IEnumerable<int> list, int length)
        {
            if (list == null)
            {
                return null;
            }

            if (length == 1)
            {
                return list.Select(t => new[] { t });
            }

            var permutations = GeneratePermutations(list, length - 1).SelectMany(p => list.Where(x => !p.Contains(x)), (p1, p2) => p1.Concat(new[] { p2 }));

            return permutations;
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

        private bool IsPythagoreanTriples(List<int> source)
        {
            return (source.First() * source.First()) + (source.ElementAt(1) * source.ElementAt(1)) == source.Last() * source.Last();
        }
    }
}
