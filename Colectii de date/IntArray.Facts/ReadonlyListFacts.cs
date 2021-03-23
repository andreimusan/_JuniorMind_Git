using System;
using Xunit;

namespace Arrays.Facts
{
    public class ReadonlyListFacts
    {
        [Fact]
        public void TestAddException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList.Add(10));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void TestIndexerSetException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList[1] = 10);
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void TestInsertException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList.Insert(1, 20));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void TestClearException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList.Clear());
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void TestRemoveException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList.Remove(5));
            Assert.Equal("Collection is read-only.", exception.Message);
        }

        [Fact]
        public void TestRemoveAtException()
        {
            var list = new List<int> { 7, 3, 5, 7, 20, 30 };
            var readonlyList = new ReadonlyList<int> { };
            readonlyList = (ReadonlyList<int>)list;

            var exception = Assert.Throws<NotSupportedException>(() => readonlyList.RemoveAt(2));
            Assert.Equal("Collection is read-only.", exception.Message);
        }
    }
}
