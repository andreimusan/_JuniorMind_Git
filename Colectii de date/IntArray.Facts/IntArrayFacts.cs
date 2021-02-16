using System;
using Xunit;

namespace Arrays.Facts
{
    public class IntArrayFacts
    {
        [Fact]
        public void TestAdd()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(20);
            array.Add(5);
            array.Add(7);
            array.Add(100);

            Assert.Equal(5, array.Count);
            Assert.Equal(100, array[4]);
        }

        [Fact]
        public void TestCount()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);

            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void TestElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void TestSetElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.Equal(20, array[1]);
        }

        [Fact]
        public void TestContainsTrue()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.Equal(1, array.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array[1] = 20;

            Assert.Equal(-1, array.IndexOf(5));
        }

        [Fact]
        public void TestInsert()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Insert(1, 20);

            Assert.Equal(4, array.Count);
            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestClear()
        {
            var array = new IntArray();
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
            var array = new IntArray();
            array.Add(7);
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.Add(20);
            array.Remove(7);
            array.Add(30);

            Assert.Equal(5, array.Count);
            Assert.Equal(30, array[4]);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var array = new IntArray();
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

        [Fact]
        public void TestRemoveAt2()
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.RemoveAt(1);

            Assert.Equal(3, array.Count);
            Assert.Equal(1, array.IndexOf(5));
        }
    }
}
