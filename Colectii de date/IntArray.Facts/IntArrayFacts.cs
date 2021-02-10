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

            Assert.Equal(1, array.Count());
        }

        [Fact]
        public void TestCount()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);

            Assert.Equal(3, array.Count());
        }

        [Fact]
        public void TestElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);

            Assert.Equal(5, array.Element(1));
        }

        [Fact]
        public void TestSetElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.SetElement(1, 20);

            Assert.Equal(20, array.Element(1));
        }

        [Fact]
        public void TestContainsTrue()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.SetElement(1, 20);

            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.SetElement(1, 20);

            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.SetElement(1, 20);

            Assert.Equal(1, array.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var array = new IntArray();
            array.Add(3);
            array.Add(5);
            array.Add(7);
            array.SetElement(1, 20);

            Assert.Equal(-1, array.IndexOf(5));
        }
    }
}
