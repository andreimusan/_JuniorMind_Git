﻿using System;
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

        public IntOperations(int[] array, int sum = 0, int number = 0)
        {
            this.array = array;
            this.newArray = array;
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
            var negativeValues = Enumerable.Range(-number, number).Select(x => x);
            var positiveValues = Enumerable.Range(0, number + 1).Select(x => x);
            newArray = Enumerable.Range(-number, number + number + 1).Select(x => x).Except(zero);
            var result = this.GenerateCombinations().Where(value => value.Sum() == sum).ToList();

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
