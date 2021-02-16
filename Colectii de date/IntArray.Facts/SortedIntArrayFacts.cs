using System;
using Xunit;

namespace Arrays.Facts
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void TestAdd()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(20);
            array.Add(5);
            array.Add(2);
            array.Add(100);

            Assert.Equal(5, array.Count);
            Assert.Equal(20, array[3]);
            Assert.Equal(2, array[0]);
        }

        [Fact]
        public void TestCount()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);

            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void TestElement()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(20);
            array.Add(7);
            array.Add(5);

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void TestSetElementTrue()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 4;

            Assert.Equal(4, array[1]);
        }

        [Fact]
        public void TestSetElementFalse()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void TestContainsTrue()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Add(20);

            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.False(array.Contains(20));
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Add(20);

            Assert.Equal(3, array.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.Equal(-1, array.IndexOf(20));
        }

        [Fact]
        public void TestInsertTrue()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Insert(1, 4);

            Assert.Equal(4, array.Count);
            Assert.True(array.Contains(4));
            Assert.Equal(1, array.IndexOf(4));
        }

        [Fact]
        public void TestInsertFalse()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Insert(1, 20);

            Assert.Equal(3, array.Count);
            Assert.False(array.Contains(20));
        }

        [Fact]
        public void TestClear()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Clear();

            Assert.Equal(0, array.Count);
            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestRemove()
        {
            var array = new SortedIntArray();
            array.Add(7);
            array.Add(5);
            array.Add(3);
            array.Add(7);
            array.Add(30);
            array.Remove(7);
            array.Add(20);

            Assert.Equal(5, array.Count);
            Assert.Equal(5, array[1]);
            Assert.Equal(20, array[3]);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var array = new SortedIntArray();
            array.Add(7);
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Add(20);
            array.Add(30);
            array.RemoveAt(3);
            array.Add(40);

            Assert.Equal(6, array.Count);
            Assert.Equal(3, array.IndexOf(20));
            Assert.Equal(5, array.IndexOf(40));
        }
    }
}
