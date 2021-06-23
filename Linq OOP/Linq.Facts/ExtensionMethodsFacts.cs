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
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => array.All(null));
            Assert.Equal("predicate", exception.Message);
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
            Assert.Equal("source", exception.Message);
        }

        [Fact]
        public void TestFirst()
        {
            var array = new char[] { 'd', 'x', 'b', 'c', 'y' };
            char existingFirst = array.First(c => c > 'a' && c < 'd');
            string exceptionArray = null;

            Assert.Equal('b', existingFirst);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.First(c => c > 'a'));
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => array.First(null));
            Assert.Equal("predicate", exception.Message);

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

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Select(c => c.Length > 2).GetEnumerator().MoveNext());
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.Select((Func<string, int>)null).GetEnumerator().MoveNext());
            Assert.Equal("selector", exception.Message);
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

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.SelectMany(c => c).GetEnumerator().MoveNext());
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.SelectMany((Func<string, IEnumerable<int>>)null).GetEnumerator().MoveNext());
            Assert.Equal("selector", exception.Message);
        }

        [Fact]
        public void TestWhere()
        {
            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> result = fruits.Where(fruit => fruit.Length < 6);

            string exceptionArray = null;

            Assert.Equal(new string[] { "apple", "mango", "grape" }, result);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Where(c => c > 'a').GetEnumerator().MoveNext());
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.Where(null).GetEnumerator().MoveNext());
            Assert.Equal("predicate", exception.Message);
        }

        [Fact]
        public void TestToDictionary()
        {
            string[] fruits = new string[] { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };

            var result = fruits.ToDictionary(item => item, item => true);

            string exceptionArray = null;

            Assert.True(result.ContainsKey("mango"));

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.ToDictionary(item => item, item => true));
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.ToDictionary((Func<string, string>)null, item => true));
            Assert.Equal("keySelector", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => fruits.ToDictionary(item => item, (Func<string, string>)null));
            Assert.Equal("elementSelector", exception.Message);
        }

        [Fact]
        public void TestZip()
        {
            int[] integers1 = new int[] { 1, 2, 3, 4, 5 };
            int[] integers2 = new int[] { 10, 20, 30, 40, 50 };
            var result = integers1.Zip(integers2, (i, j) => i + j);

            string exceptionArray = null;

            Assert.Equal(22, result.ElementAt(1));

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Zip(integers2, (first, second) => first + " " + second).GetEnumerator().MoveNext());
            Assert.Equal("first", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => integers1.Zip(exceptionArray, (first, second) => first + " " + second).GetEnumerator().MoveNext());
            Assert.Equal("second", exception.Message);
        }

        [Fact]
        public void TestAggregate()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            int numEven = ints.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total);

            string exceptionArray = null;

            Assert.Equal(6, numEven);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Aggregate(0, (total, next) => next % 2 == 0 ? total + 1 : total));
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => ints.Aggregate(0, (Func<int, int, int>)null));
            Assert.Equal("func", exception.Message);
        }

        [Fact]
        public void TestJoin()
        {
            int[] outer = { 5, 3, 7 };
            string[] inner = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };
            var query = outer.Join(inner,
                            outerElement => outerElement,
                            innerElement => innerElement.Length,
                            (outerElement, innerElement) => outerElement + ":" + innerElement);

            Assert.Equal("3:bee", query.ElementAt(1));

            string exceptionOuter = null;
            string[] exceptionInner = null;

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionOuter.Join(inner,
                           outerElement => outerElement,
                           innerElement => innerElement.Length,
                           (outerElement, innerElement) => outerElement + ":" + innerElement).GetEnumerator().MoveNext());
            Assert.Equal("outer", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => outer.Join(exceptionInner,
                           outerElement => outerElement,
                           innerElement => innerElement.Length,
                           (outerElement, innerElement) => outerElement + ":" + innerElement).GetEnumerator().MoveNext());
            Assert.Equal("inner", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => outer.Join(inner,
                           (Func<int, int>)null,
                           innerElement => innerElement.Length,
                           (outerElement, innerElement) => outerElement + ":" + innerElement).GetEnumerator().MoveNext());
            Assert.Equal("outerKeySelector", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => outer.Join(inner,
                           outerElement => outerElement,
                           (Func<string, int>)null,
                           (outerElement, innerElement) => outerElement + ":" + innerElement).GetEnumerator().MoveNext());
            Assert.Equal("innerKeySelector", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => outer.Join(inner,
                           outerElement => outerElement,
                           innerElement => innerElement.Length,
                           (Func<int, string, string>)null).GetEnumerator().MoveNext());
            Assert.Equal("resultSelector", exception.Message);
        }

        [Fact]
        public void TestDistinct()
        {
            List<int> intCollection = new List<int>() { 1, 2, 3, 2, 3, 4, 4, 5, 6, 3, 4, 5 };
            IEnumerable<int> distinctCollection = new List<int> { 1, 2, 3, 4, 5, 6 };
            var distinct = intCollection.Distinct(EqualityComparer<int>.Default);

            string[] exceptionArray = null;

            Assert.Equal(distinctCollection, distinct);

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Distinct(EqualityComparer<string>.Default).GetEnumerator().MoveNext());
            Assert.Equal("source", exception.Message);
        }

        [Fact]
        public void TestUnion()
        {
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };
            IEnumerable<int> unionCollection = new List<int> { 5, 3, 9, 7, 8, 6, 4, 1, 0 };

            var union = ints1.Union(ints2, EqualityComparer<int>.Default);

            Assert.Equal(unionCollection, union);

            string[] exceptionArray = null;
            string[] sequence = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Union(sequence, EqualityComparer<string>.Default));
            Assert.Equal("first", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => sequence.Union(exceptionArray, EqualityComparer<string>.Default));
            Assert.Equal("second", exception.Message);
        }

        [Fact]
        public void TestIntersect()
        {
            var ints1 = new[] { 10, 2, 1, 2 }.Select(x => 10 / x);
            int[] ints2 = { 1 };
            IEnumerable<int> intersectCollection = new List<int> { 1 };

            var intersect = ints1.Intersect(ints2, EqualityComparer<int>.Default);

            Assert.Equal(intersectCollection, intersect);

            string[] exceptionArray = null;
            string[] sequence = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Intersect(sequence, EqualityComparer<string>.Default));
            Assert.Equal("first", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => sequence.Intersect(exceptionArray, EqualityComparer<string>.Default));
            Assert.Equal("second", exception.Message);
        }

        [Fact]
        public void TestExcept()
        {
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };
            IEnumerable<int> exceptCollection = new List<int> { 5, 7 };

            var except = ints1.Except(ints2, EqualityComparer<int>.Default);

            Assert.Equal(exceptCollection, except);

            string[] exceptionArray = null;
            string[] sequence = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.Except(sequence, EqualityComparer<string>.Default));
            Assert.Equal("first", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => sequence.Except(exceptionArray, EqualityComparer<string>.Default));
            Assert.Equal("second", exception.Message);
        }

        [Fact]
        public void TestGroupBy()
        {
            string[] sequence = { "abc", "hello", "def", "there", "four" };
            var groups = sequence.GroupBy(x => x.Length,
                                        x => x,
                                        (key, values) => key + ":" + string.Join(";", values),
                                        EqualityComparer<int>.Default);
            IEnumerable<string> groupCollection = new List<string> { "3:abc;def", "5:hello;there", "4:four" };

            Assert.Equal(groupCollection, groups);

            string[] exceptionArray = null;

            var exception = Assert.Throws<ArgumentNullException>(() => exceptionArray.GroupBy(x => x.Length, x => x, (key, values) => key + ":" + string.Join(";", values), EqualityComparer<int>.Default));
            Assert.Equal("source", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => sequence.GroupBy((Func<string, int>)null, x => x, (key, values) => key + ":" + string.Join(";", values), EqualityComparer<int>.Default));
            Assert.Equal("keySelector", exception.Message);

            exception = Assert.Throws<ArgumentNullException>(() => sequence.GroupBy(x => x.Length, (Func<string, string>)null, (key, values) => key + ":" + string.Join(";", values), EqualityComparer<int>.Default));
            Assert.Equal("elementSelector", exception.Message);
        }

        [Fact]
        public void TestOrderBy()
        {
            string[] fruits = { "orange", "mango", "cherry", "strawberry", "berry", "grapes", "grapefruit" };
            var result = fruits.OrderBy(x => x.Length, null).ToList();

            IEnumerable<string> orderedFruits = new List<string> { "mango", "berry", "orange", "cherry", "grapes", "strawberry", "grapefruit" };

            Assert.Equal(orderedFruits, result);
        }
    }
}
