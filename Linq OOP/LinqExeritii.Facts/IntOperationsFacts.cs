using LinqExercitii;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace LinqExeritii.Facts
{
    public class IntOperationsFacts
    {
        [Fact]
        public void TestGenerateCombinationsWithSumLessThanNumber()
        {
            var intOperation = new IntOperations(new int[] { 1, 2, 3, 4 }, 6);
            var result = intOperation.GenerateSubArraysWithSumLessThanNumber();
            var options = new List<int[]>() 
            {
                new[] { 1 },
                new[] { 2 },
                new[] { 3 },
                new[] { 4 },
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 1, 2, 3 }
            };

            Assert.Equal(options, result);
        }

        [Fact]
        public void TestGenerateCombinations()
        {
            var intOperation = new IntOperations(new int[] { 1, 2, 3, 4 }, 6);
            var result = intOperation.GenerateCombinations().ToList();
            var options = new List<List<int>>()
            {
                new List<int> { 1, 2, 3, 4 },
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 2, 4 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3, 4 },
                new List<int> { 1, 3 },
                new List<int> { 1, 4 },
                new List<int> { 1 },
                new List<int> { 2, 3, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { }
            };

            Assert.Equal(options, result);
        }

        [Fact]
        public void TestGenerateCombinationsWithSumEqualToNumber()
        {
            var intOperation = new IntOperations(new int[] { 1, 2, 3, 4 }, 2, 4);

            var result = intOperation.GenerateCombinationsWithSumEqualToNumber();
            var options = new List<int[]>()
            {
                new[] { -1, 2, -3, 4 },
                new[] { -1, 2, -3, 4 },
                new[] { -1, 2, -3, 4 },
                new[] { -1, 2, -3, 4 }
            };

            Assert.Equal(options, result);
        }

        [Fact]
        public void TestGeneratePythagoreanTriples()
        {
            var intOperation = new IntOperations(new int[] { 6, 5, 3, 4, 10, 8 });
            var result = intOperation.GeneratePythagoreanTriples();
            var options = new List<List<int>>()
            {
                new List<int> { 6, 8, 10 },
                new List<int> { 8, 6, 10 },
                new List<int> { 3, 4, 5 },
                new List<int> { 4, 3, 5 }
            };

            Assert.Equal(options, result);
        }

        [Fact]
        public void TestGeneratePermutations()
        {
            var intOperation = new IntOperations(new int[] { 5, 3, 4 });
            var result = intOperation.GeneratePermutations(new List<int> { 5, 3, 4 }, 3);
            var options = new List<List<int>>()
            {
                new List<int> { 5, 3, 4 },
                new List<int> { 5, 4, 3 },
                new List<int> { 3, 5, 4 },
                new List<int> { 3, 4, 5 },
                new List<int> { 4, 5, 3 },
                new List<int> { 4, 3, 5 }
            };

            Assert.Equal(options, result);
        }
    }
}
