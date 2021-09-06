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
            var result = intOperation.GenerateSubArraysWithSumLessThanNumber().Cast<List<int>>().ToList();
            var options = new List<List<int>>() 
            {
                new List<int> { 1 },
                new List<int> { 2 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { 1, 2 },
                new List<int> { 2, 3 },
                new List<int> { 1, 2, 3 }
            };

            Assert.Equal(result, options);
        }

        [Fact]
        public void TestGenerateCombinations()
        {
            var array = new int[] { 1, 2, 3, 4 };
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

            Assert.Equal(result, options);
        }

        [Fact]
        public void TestGenerateCombinationsWithSumEqualToNumber()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var intOperation = new IntOperations(new int[] { 1, 2, 3, 4 }, 2, 3);
            var result = intOperation.GenerateCombinationsWithSumEqualToNumber();
            var options = new List<List<int>>()
            {
                new List<int> { -3, -1, 1, 2, 3 },
                new List<int> { -3, 2, 3 },
                new List<int> { -2, -1, 2, 3 },
                new List<int> { -2, 1, 3 },
                new List<int> { -1, 1, 2 },
                new List<int> { -1, 3 },
                new List<int> { 2 }
            };

            Assert.Equal(result, options);
        }
    }
}
