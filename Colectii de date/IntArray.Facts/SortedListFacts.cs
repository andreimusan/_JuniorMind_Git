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

            Assert.Equal(1, list.Count);
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

            Assert.True(list.Contains(20));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list[1] = 20;

            Assert.False(list.Contains(20));
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
            Assert.True(list.Contains(4));
            Assert.Equal(1, list.IndexOf(4));
        }

        [Fact]
        public void TestInsertFalse()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list.Insert(0, 20);

            Assert.Equal(3, list.Count);
            Assert.False(list.Contains(20));
        }

        [Fact]
        public void TestClear()
        {
            var list = new SortedList<int>() { 3, 5, 7 };
            list.Clear();

            Assert.Equal(0, list.Count);
            Assert.False(list.Contains(5));
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
    }
}
