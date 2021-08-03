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
            var result = intOperation.GenerateSubArrayWithSumLessThanNumber().Cast<List<int>>().ToList();
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
    }
}
