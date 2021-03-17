using System;
using Xunit;

namespace Arrays.Facts
{
    public class SortedListFacts
    {
        [Fact]
        public void TestAdd()
        {
            var list = new SortedList<int>() { 3, 20, 5, 2, 100 };

            Assert.Equal(5, list.Count);
            Assert.Equal(20, list[3]);
            Assert.Equal(2, list[0]);
        }

        [Fact]
        public void TestCount()
        {
            var list = new SortedList<int>() { 3, 5, 7 };

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestElement()
        {
            var list = new SortedList<int>() { 3, 20, 7, 5 };

            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void TestSetElementTrue()
        {
            var list = new SortedList<int>() { 3, 7, 5 };
            list[1] = 4;

            Assert.Equal(4, list[1]);
        }

        [Fact]
        public void TestSetElementTrue2()
        {
            var list = new SortedList<int>() { 3 };
            list[1] = 2;

            Assert.Single(list);
        }

        [Fact]
        public void TestSetElementFalse()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list[1] = 20;

            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void TestContainsTrue()
        {
            var list = new SortedList<int>() { 3, 5, 7, 20 };

            Assert.Contains(20, list);
        }

        [Fact]
        public void TestContainsFalse()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list[1] = 20;

            Assert.DoesNotContain(20, list);
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var list = new SortedList<int>() { 3, 5, 7, 20 };

            Assert.Equal(3, list.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list[1] = 20;

            Assert.Equal(-1, list.IndexOf(20));
        }

        [Fact]
        public void TestInsertTrue()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list.Insert(1, 4);

            Assert.Equal(4, list.Count);
            Assert.Contains(4, list);
            Assert.Equal(1, list.IndexOf(4));
        }

        [Fact]
        public void TestInsertFalse()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list.Insert(0, 20);

            Assert.Equal(3, list.Count);
            Assert.DoesNotContain(20, list);
        }

        [Fact]
        public void TestClear()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list.Clear();

            Assert.Empty(list);
            Assert.DoesNotContain(5, list);
        }

        [Fact]
        public void TestRemove()
        {
            var list = new SortedList<int>() { 7, 5, 3, 7, 30 };
            list.Remove(7);
            list.Add(20);

            Assert.Equal(5, list.Count);
            Assert.Equal(5, list[1]);
            Assert.Equal(20, list[3]);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var list = new SortedList<int>() { 7, 5, 3, 7, 20, 30 };
            list.RemoveAt(3);
            list.Add(40);

            Assert.Equal(6, list.Count);
            Assert.Equal(3, list.IndexOf(20));
            Assert.Equal(5, list.IndexOf(40));
        }

        [Fact]
        public void TestSortedListChar()
        {
            var list = new SortedList<int>() { 'a', 'e', 'd', 'c', 'b' };
            list.RemoveAt(2);
            list.Add('b');
            list.Insert(4, 'd');

            Assert.Equal(6, list.Count);
            Assert.Equal('b', list[1]);
            Assert.Equal('e', list[5]);
        }

        [Fact]
        public void TestIndexerGetException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[-1]);
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestIndexerSetException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[10] = 10);
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '10')", exception.Message);
        }

        [Fact]
        public void TestInsertException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 20));
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestRemoveAtException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(20));
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '20')", exception.Message);
        }

        [Fact]
        public void TestCopyToNullException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };
            int[] array = null;

            var exception = Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 0));
            Assert.Equal("Array is null. (Parameter '0')", exception.Message);
        }

        [Fact]
        public void TestCopyToOutOfRangeException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };
            var array = new int[8];

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
            Assert.Equal("Index was out of range. Must be positive. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestCopyToArgumentException()
        {
            var list = new SortedList<int> { 7, 3, 5, 7, 20, 30 };
            var array = new int[8];

            var exception = Assert.Throws<ArgumentException>(() => list.CopyTo(array, 8));
            Assert.Equal("The number of elements to copy is greater than the available space in the array.", exception.Message);
        }
    }
}
