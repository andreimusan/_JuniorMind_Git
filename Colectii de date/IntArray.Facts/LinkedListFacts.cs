using System;
using Xunit;

namespace Arrays.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void TestAddLast()
        {
            var list = new LinkedList<int> ();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestAddFirst()
        {
            var list = new LinkedList<int> ();
            list.AddFirst(3);
            list.AddFirst(8);
            list.AddFirst(5);

            Assert.Equal(3, list.Count);
        }
    }
}
