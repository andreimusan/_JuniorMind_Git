using System;
using Xunit;

namespace Arrays.Facts
{
    public class LinkedListNodeFacts
    {
        [Fact]
        public void TestListNullProp()
        {
            var linkedListNode = new LinkedListNode<string>("orange");

            Assert.Null(linkedListNode.List);
            Assert.Null(linkedListNode.Previous);
            Assert.Equal("orange", linkedListNode.Value);
            Assert.Null(linkedListNode.Next);
        }

        [Fact]
        public void TestListProp1Node()
        {
            var linkedListNode = new LinkedListNode<string>("orange");
            var list = new LinkedList<string>();
            list.AddLast(linkedListNode);

            Assert.Equal(1, linkedListNode.List.Count);
            Assert.Equal("orange", linkedListNode.Value);
        }

        [Fact]
        public void TestListPropMultipleNodes()
        {
            var linkedListNode = new LinkedListNode<string>("orange");
            var list = new LinkedList<string>();
            list.AddLast(linkedListNode);
            list.AddFirst("yellow");
            list.AddLast("red");

            Assert.Equal(3, linkedListNode.List.Count);
            Assert.Equal("yellow", (System.Collections.Generic.IEnumerable<char>)linkedListNode.Previous.Value);
            Assert.Equal("orange", linkedListNode.Value);
            Assert.Equal("red", (System.Collections.Generic.IEnumerable<char>)linkedListNode.Next.Value);
        }
    }
}
