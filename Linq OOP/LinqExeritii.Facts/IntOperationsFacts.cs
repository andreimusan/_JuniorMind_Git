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
                new[] { 1, 2 },
                new[] { 1, 2, 3 },
                new[] { 2 },
                new[] { 2, 3 },
                new[] { 3 },
                new[] { 4 }
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
                new[] { 1, 2, 3, -4 }
            };

            Assert.Equal(options, result);
        }

        [Fact]
        public void TestGeneratePythagoreanTriples()
        {
            var intOperation = new IntOperations(new int[] { 6, 5, 3, 4, 10, 8 });
            var result = intOperation.GeneratePythagoreanTriples();
            var options = new List<int[]>()
            {
                new[] { 6, 8, 10 },
                new[] { 3, 4, 5 },
                new[] { 4, 3, 5 },
                new[] { 8, 6, 10 }
            };

            Assert.Equal(options, result);
        }
    }
}
