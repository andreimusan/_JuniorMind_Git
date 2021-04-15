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

        [Fact]
        public void TestAddFirstAndAddLast()
        {
            var linkedListNode = new LinkedListNode<int>(3);
            var list = new LinkedList<int>();

            list.AddLast(linkedListNode);
            list.AddFirst(5);
            list.AddLast(8);

            Assert.Equal(3, list.Count);
            Assert.Equal(5, linkedListNode.Previous.Value);
            Assert.Equal(8, linkedListNode.Next.Value);
        }

        [Fact]
        public void TestAddBeforeWithValue()
        {
            var linkedListNode = new LinkedListNode<int>(4);
            var list = new LinkedList<int>();

            list.AddLast(linkedListNode);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(5);
            list.AddBefore(linkedListNode, 3);

            Assert.Equal(5, list.Count);
            Assert.Equal(3, linkedListNode.Previous.Value);
            Assert.Equal(2, linkedListNode.Previous.Previous.Value);
        }

        [Fact]
        public void TestAddBeforeWithNode()
        {
            var linkedListNode = new LinkedListNode<int>(4);
            var list = new LinkedList<int>();

            var linkedListNodeToAdd = new LinkedListNode<int>(3);

            list.AddLast(linkedListNode);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddLast(5);
            list.AddBefore(linkedListNode, linkedListNodeToAdd);

            Assert.Equal(5, list.Count);
            Assert.Equal(2, linkedListNodeToAdd.Previous.Value);
            Assert.Equal(4, linkedListNodeToAdd.Next.Value);
        }

        [Fact]
        public void TestAddAfterWithValue()
        {
            var linkedListNode = new LinkedListNode<int>(2);
            var list = new LinkedList<int>();

            list.AddLast(linkedListNode);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddLast(5);
            list.AddAfter(linkedListNode, 3);

            Assert.Equal(5, list.Count);
            Assert.Equal(3, linkedListNode.Next.Value);
            Assert.Equal(4, linkedListNode.Next.Next.Value);
        }

        [Fact]
        public void TestAddAfterWithNode()
        {
            var linkedListNode = new LinkedListNode<int>(2);
            var list = new LinkedList<int>();

            var linkedListNodeToAdd = new LinkedListNode<int>(3);

            list.AddLast(linkedListNode);
            list.AddFirst(1);
            list.AddLast(4);
            list.AddLast(5);
            list.AddAfter(linkedListNode, linkedListNodeToAdd);

            Assert.Equal(5, list.Count);
            Assert.Equal(2, linkedListNodeToAdd.Previous.Value);
            Assert.Equal(4, linkedListNodeToAdd.Next.Value);
        }

        [Fact]
        public void TestClear()
        {
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);
            list.Clear();

            Assert.Equal(0, list.Count);
            Assert.Null(list.First);
            Assert.Null(list.Last);
        }
    }
}
