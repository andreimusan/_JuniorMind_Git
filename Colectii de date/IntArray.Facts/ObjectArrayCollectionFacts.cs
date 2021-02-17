using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Arrays.Facts
{
    public class ObjectArrayCollectionFacts
    {
        [Fact]
        public void TestAdd()
        {
            var array = new ObjectArrayCollection { 3, 20, 5, 7, 100 };

            Assert.Equal(5, array.Count);
            Assert.Equal(100, array[4]);
        }

        [Fact]
        public void TestAddChar()
        {
            var array = new ObjectArrayCollection { 'a', 'b', 'c', 'd', 'e' };

            Assert.Equal(5, array.Count);
            Assert.Equal('b', array[1]);
        }

        [Fact]
        public void TestCount()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };

            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void TestElement()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };

            Assert.Equal(5, array[1]);
        }

        [Fact]
        public void TestSetElement()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array[1] = 20;

            Assert.Equal(20, array[1]);
        }

        [Fact]
        public void TestSetElementChar()
        {
            var array = new ObjectArrayCollection { 'a', 'b', 'c', 'd', 'e' };
            array[1] = 'z';

            Assert.Equal('z', array[1]);
        }

        [Fact]
        public void TestContainsTrue()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array[1] = 20;

            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestContainsFalse()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array[1] = 20;

            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestContainsCharFalse()
        {
            var array = new ObjectArrayCollection { 'a', 'b', 'c', 'd', 'e' };
            array[1] = 20;

            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestIndexOfExistingElement()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array[1] = 20;

            Assert.Equal(1, array.IndexOf(20));
        }

        [Fact]
        public void TestIndexOfNotExistingElement()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array[1] = 20;

            Assert.Equal(-1, array.IndexOf(5));
        }

        [Fact]
        public void TestInsert()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array.Insert(1, 20);

            Assert.Equal(4, array.Count);
            Assert.True(array.Contains(20));
        }

        [Fact]
        public void TestClear()
        {
            var array = new ObjectArrayCollection { 3, 5, 7 };
            array.Clear();

            Assert.Equal(0, array.Count);
            Assert.False(array.Contains(5));
        }

        [Fact]
        public void TestRemove()
        {
            var array = new ObjectArrayCollection { 7, 3, 5, 7, 20 };
            array.Remove(7);
            array.Add(30);

            Assert.Equal(5, array.Count);
            Assert.Equal(30, array[4]);
        }

        [Fact]
        public void TestRemoveAt()
        {
            var array = new ObjectArrayCollection { 7, 3, 5, 7, 20, 30 };
            array.RemoveAt(3);
            array.Add(40);

            Assert.Equal(6, array.Count);
            Assert.Equal(3, array.IndexOf(20));
            Assert.Equal(5, array.IndexOf(40));
        }
    }
}
