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
        public void TestGenerateTextSubstringPalindrome()
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

            Assert.True(result.SequenceEqual(options));
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
                new List<int> { 2, 3, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { }
            };

            Assert.True(result.SequenceEqual(options));
        }

        [Fact]
        public void TestGenerateCombinationsWithSumEqualToNumber()
        {
            var array = new int[] { 1, 2, 3, 4 };
            var intOperation = new IntOperations(new int[] { 1, 2, 3, 4 }, 6, 4);
            var result = intOperation.GenerateCombinationsWithSumEqualToNumber();
            var options = new List<List<int>>()
            {
                new List<int> { 1, 2, 3, 4 },
                new List<int> { 1, 2, 3 },
                new List<int> { 1, 2, 4 },
                new List<int> { 1, 2 },
                new List<int> { 1, 3, 4 },
                new List<int> { 1, 3 },
                new List<int> { 1, 4 },
                new List<int> { 2, 3, 4 },
                new List<int> { 2, 3 },
                new List<int> { 2, 4 },
                new List<int> { 2 },
                new List<int> { 3, 4 },
                new List<int> { 3 },
                new List<int> { 4 },
                new List<int> { }
            };

            Assert.True(result.SequenceEqual(options));
        }
    }
}
