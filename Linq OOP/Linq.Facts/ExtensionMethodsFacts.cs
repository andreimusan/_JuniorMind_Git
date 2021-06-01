using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Linq.Facts
{
    public class ExtensionMethodsFacts
    {
        [Fact]
        public void TestAll()
        {
            var array = new int[] { 2, 4, 6, 8 };
            bool isEven = array.All(n => n % 2 == 0);
            bool isGreaterThanFive = array.All(n => n > 5);
            string exceptionArray = null;

            Assert.True(isEven);
            Assert.False(isGreaterThanFive);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.All(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => array.All(null));
            Assert.Equal("Predicate is null.", exception.Message);
        }

        [Fact]
        public void TestAny()
        {
            var array = new char[] { 'b', 'd', 'x', 'y' };
            bool isBetweenAAndC = array.Any(c => c > 'a' && c < 'c');
            bool isGreaterThanZ = array.Any(c => c > 'z');
            string exceptionArray = null;

            Assert.True(isBetweenAAndC);
            Assert.False(isGreaterThanZ);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Any(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);
        }

        [Fact]
        public void TestFirst()
        {
            var array = new char[] { 'd', 'x', 'b', 'c', 'y' };
            char existingFirst = array.First(c => c > 'a' && c < 'd');
            string exceptionArray = null;

            Assert.Equal('b', existingFirst);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.First(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => array.First(null));
            Assert.Equal("Predicate is null.", exception.Message);

            var notExistingException = Assert.Throws<InvalidOperationException>(() => array.First(c => c > 'z'));
            Assert.Equal("No element was found.", notExistingException.Message);
        }

        [Fact]
        public void TestSelect()
        {
            int[] numbers = { 2, 55, 67, 82, 99, 13 };
            var result = numbers.Select(x => x / 2);

            Assert.Equal(new int[] { 1, 27, 33, 41, 49, 6 }, result);

            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
            string[] exceptionArray = null;

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Select(c => c.Length > 2));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.Select((Func<string, int>)null));
            Assert.Equal("Selector is null.", exception.Message);
        }

        [Fact]
        public void TestSelectMany()
        {
            int[][] arrays = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 7, 8},
                new[] {12, 14}
            };
            IEnumerable<int> result = arrays.SelectMany(array => array);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 12, 14 }, result);

            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
            string[] exceptionArray = null;

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.SelectMany(c => c));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.SelectMany((Func<string, IEnumerable<int>>)null));
            Assert.Equal("Selector is null.", exception.Message);
        }

        [Fact]
        public void TestWhere()
        {
            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> result = fruits.Where(fruit => fruit.Length < 6);

            string exceptionArray = null;

            Assert.Equal(new string[] { "apple", "mango", "grape" }, result);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Where(c => c > 'a'));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.Where(null));
            Assert.Equal("Predicate is null.", exception.Message);
        }

        [Fact]
        public void TestToDictionary()
        {
            string[] fruits = new string[] { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };

            var result = fruits.ToDictionary(item => item, item => true);

            string exceptionArray = null;

            Assert.True(result.ContainsKey("mango"));

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.ToDictionary(item => item, item => true));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.ToDictionary((Func<string, string>)null, item => true));
            Assert.Equal("KeySelector is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.ToDictionary(item => item, (Func<string, string>)null));
            Assert.Equal("ElementSelector is null.", exception.Message);
        }

        [Fact]
        public void TestZip()
        {
            int[] integers1 = new int[] { 1, 2, 3, 4, 5 };
            int[] integers2 = new int[] { 10, 20, 30, 40, 50 };
            var result = integers1.Zip(integers2, (i, j) => i + j);

            string exceptionArray = null;

            Assert.Equal(22, result.ElementAt(1));

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Zip(integers2, (first, second) => first + " " + second));
            Assert.Equal("The first sequence is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => integers1.Zip(exceptionArray, (first, second) => first + " " + second));
            Assert.Equal("The second sequence is null.", exception.Message);
        }

        [Fact]
        public void TestAggregate()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            int numEven = ints.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);

            string exceptionArray = null;

            Assert.Equal(6, numEven);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total));
            Assert.Equal("Source is null.", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => ints.Aggregate(0, (Func<int, int, int>)null));
            Assert.Equal("Function is null.", exception.Message);
        }
    }
}
