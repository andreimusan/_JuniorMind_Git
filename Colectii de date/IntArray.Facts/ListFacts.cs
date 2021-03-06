﻿using System;
using Xunit;

namespace Arrays.Facts
{
    public class ListFacts
    {
        [Fact]
        public void TestAdd()
        {
            var list = new List<int> { 3, 20, 5, 7, 100 };

            Assert.Equal(5, list.Count);
            Assert.Equal(100, list[4]);
        }

        [Fact]
        public void TestAddChar()
        {
            var list = new List<Char> { 'a', 'b', 'c', 'd', 'e' };

            Assert.Equal(5, list.Count);
            Assert.Equal('b', list[1]);
        }

        [Fact]
        public void TestCount()
        {
            var list = new List<int> { 3, 5, 7 };

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestElement()
        {
            var list = new List<int> { 3, 5, 7 };

            Assert.Equal(5, list[1]);
        }

        [Fact]
        public void TestSetElement()
        {
            var list = new List<int> { 3, 5, 7 };
            list[1] = 20;

            Assert.Equal(20, list[1]);
        }

        [Fact]
        public void TestSetElementChar()
        {
            var list = new List<Char> { 'a', 'b', 'c', 'd', 'e' };
            list[1] = 'z';

            Assert.Equal('z', list[1]);
        }

        [Fact]
        public void TestContainsTrue()
        {
            var list = new List<int> { 3, 5, 7 };
            list[1] = 20;

            Assert.Contains(20, list);
        }

        [Fact]
        public void TestContainsFalse()
        {
            var list = new List<int> { 3, 5, 7 };
            list[1] = 20;

            Assert.DoesNotContain(5, list);
        }

        [Fact]
        public void TestContainsCharFalse()
        {
            var list = new List<Char> { 'a', 'b', 'c', 'd', 'e' };
            list[1] = '2';

            Assert.DoesNotContain('5', list);
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var list = new List<int> { 3, 5, 7 };
            list[1] = 20;

            Assert.Equal(1, list.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var list = new List<int> { 3, 5, 7 };
            list[1] = 20;

            Assert.Equal(-1, list.IndexOf(5));
        }

        [Fact]
        public void TestInsert()
        {
            var list = new List<int> { 3, 5, 7 };
            list.Insert(1, 20);

            Assert.Equal(4, list.Count);
            Assert.Contains(20, list);
        }

        [Fact]
        public void TestClear()
        {
            var list = new List<int> { 3, 5, 7 };
            list.Clear();

            Assert.Empty(list);
            Assert.DoesNotContain(5, list);
        }

        [Fact]
        public void TestRemove()
        {
            var list = new List<int> { 7, 3, 5, 7, 20 };
            list.Remove(7);
            list.Add(30);

            Assert.Equal(5, list.Count);
            Assert.Equal(30, list[4]);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            list.RemoveAt(3);
            list.Add(40);

            Assert.Equal(6, list.Count);
            Assert.Equal(3, list.IndexOf(20));
            Assert.Equal(5, list.IndexOf(40));
        }

        [Fact]
        public void TestEnumerator()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var tested = false;

            foreach (var value in list)
            {
                if ((int)value == 20)
                {
                    tested = true;
                }
            }

            var a = list.GetEnumerator();
            var testedA = false;
            while (a.MoveNext())
            {
                if ((int)a.Current == 30)
                {
                    testedA = true;
                }
            }

            Assert.Equal(6, list.Count);
            Assert.True(tested);
            Assert.True(testedA);
        }

        [Fact]
        public void TestYield()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var tested = false;

            foreach (var value in list)
            {
                if ((int)value == 20)
                {
                    tested = true;
                }
            }

            Assert.Equal(6, list.Count);
            Assert.True(tested);
        }

        [Fact]
        public void TestCopyTo()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var array = new int[8];

            list.CopyTo(array, 2);

            Assert.Equal(8, array.Length);
            Assert.Equal(list[0], array[2]);
        }

        [Fact]
        public void TestIndexerGetException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[-1]);
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestIndexerSetException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list[10] = 10);
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '10')", exception.Message);
        }

        [Fact]
        public void TestInsertException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 20));
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestRemoveAtException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(20));
            Assert.Equal("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter '20')", exception.Message);
        }

        [Fact]
        public void TestCopyToNullException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            int[] array = null;

            var exception = Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 0));
            Assert.Equal("Array is null. (Parameter '0')", exception.Message);
        }

        [Fact]
        public void TestCopyToOutOfRangeException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var array = new int[8];

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
            Assert.Equal("Index was out of range. Must be positive. (Parameter '-1')", exception.Message);
        }

        [Fact]
        public void TestCopyToArgumentException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var array = new int[8];

            var exception = Assert.Throws<ArgumentException>(() => list.CopyTo(array, 8));
            Assert.Equal("The number of elements to copy is greater than the available space in the array.", exception.Message);
        }
    }
}
