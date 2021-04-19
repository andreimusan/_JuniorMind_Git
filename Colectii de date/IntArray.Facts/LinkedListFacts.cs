﻿using System;
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

        [Fact]
        public void TestContains()
        {
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            Assert.True(list.Contains(8));
            Assert.False(list.Contains(10));
        }

        [Fact]
        public void TestCopyTo()
        {
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);
            var array = new int[8];

            list.CopyTo(array, 2);

            Assert.Equal(8, array.Length);
            Assert.Equal(list.First.Value, array[2]);
        }

        [Fact]
        public void TestFind()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddFirst(8);
            list.AddLast(5);
            list.AddLast(4);
            list.AddLast(3);
            list.AddLast(2);

            Assert.Equal(linkedListNode, list.Find(2));
            Assert.Null(list.Find(10));
        }

        [Fact]
        public void TestFindLast()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);
            list.AddFirst(2);

            Assert.Equal(linkedListNode, list.FindLast(2));
            Assert.Null(list.FindLast(10));
        }

        [Fact]
        public void TestRemove()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);

            var testRemove = list.Remove(2);

            Assert.True(testRemove);
            Assert.Equal(4, list.Count);
            Assert.Equal(list.Find(5).Next, list.FindLast(8));
        }

        [Fact]
        public void TestRemoveFromFirstPosition()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);

            var testRemove = list.Remove(3);

            Assert.True(testRemove);
            Assert.Equal(4, list.Count);
            Assert.Equal(list.First, list.Find(4));
        }

        [Fact]
        public void TestRemoveFromLastPosition()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);

            var testRemove = list.Remove(8);

            Assert.True(testRemove);
            Assert.Equal(4, list.Count);
            Assert.Equal(list.Last, linkedListNode);
        }
    }
}
