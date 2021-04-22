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
            var node = new LinkedListNode<int>(3);
            list.AddLast(node);
            list.AddLast(8);
            list.AddLast(5);

            Assert.Equal(3, list.Count);
            Assert.Equal(3, node.Value);
            Assert.Equal(8, node.Next.Value);
            Assert.Equal(5, node.Previous.Value);
        }

        [Fact]
        public void TestAddFirst()
        {
            var list = new LinkedList<int> ();
            var node = new LinkedListNode<int>(3);
            list.AddFirst(node);
            list.AddFirst(8);
            list.AddFirst(5);

            Assert.Equal(3, list.Count);
            Assert.Equal(3, node.Value);
            Assert.Equal(5, node.Next.Value);
            Assert.Equal(8, node.Previous.Value);
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
        }

        [Fact]
        public void TestContains()
        {
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            Assert.Contains(5, list);
            Assert.DoesNotContain(10, list);
        }

        [Fact]
        public void TestCopyTo()
        {
            var list = new LinkedList<int>();
            var node = new LinkedListNode<int>(3);
            list.AddLast(node);
            list.AddLast(8);
            list.AddLast(5);
            var array = new int[8];

            list.CopyTo(array, 2);

            Assert.Equal(8, array.Length);
            Assert.Equal(node.Value, array[2]);
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

            list.Remove(linkedListNode);

            Assert.Equal(4, list.Count);
            Assert.Equal(list.Find(5).Next, list.FindLast(8));
        }

        [Fact]
        public void TestRemoveExistingValue()
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
        public void TestRemoveNonExistingValue()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);

            var testRemove = list.Remove(10);

            Assert.False(testRemove);
            Assert.Equal(5, list.Count);
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
            Assert.Equal(linkedListNode.Previous.Previous, list.Find(4));
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
            Assert.Equal(list.Find(3).Previous, linkedListNode);
        }

        [Fact]
        public void TestRemoveFirst()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddLast(5);
            list.AddLast(4);
            list.AddFirst(3);

            list.RemoveFirst();

            Assert.Equal(4, list.Count);
            Assert.Equal(list.FindLast(4), linkedListNode.Previous);
            Assert.Equal(list.FindLast(4).Next, linkedListNode);
        }

        [Fact]
        public void TestRemoveLast()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);

            list.RemoveLast();

            Assert.Equal(4, list.Count);
            Assert.Equal(list.Find(3).Previous, linkedListNode);
            Assert.Equal(list.Find(3), linkedListNode.Next);
        }

        [Fact]
        public void TestYield()
        {
            var list = new LinkedList<int>();
            var linkedListNode = new LinkedListNode<int>(2);
            list.AddLast(linkedListNode);
            list.AddLast(8);
            list.AddFirst(5);
            list.AddFirst(4);
            list.AddFirst(3);
            var tested = false;

            foreach (var value in list)
            {
                if ((int)value == 8)
                {
                    tested = true;
                }
            }

            Assert.Equal(5, list.Count);
            Assert.True(tested);
        }

        [Fact]
        public void TestAddLastNullException()
        {
            LinkedListNode<int> linkedListNode = null;
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            var exception = Assert.Throws<ArgumentNullException>(() => list.AddLast(linkedListNode));
            Assert.Equal("Node is null.", exception.Message);
        }

        [Fact]
        public void TestAddLastNodeBelongingToAnotherListException()
        {
            var linkedListNode = new LinkedListNode<int>(2);
            var list1 = new LinkedList<int>();
            list1.AddLast(3);
            list1.AddLast(8);
            list1.AddLast(linkedListNode);

            var list2 = new LinkedList<int>();

            var exception = Assert.Throws<InvalidOperationException>(() => list1.AddLast(linkedListNode));
            Assert.Equal("Node belongs to another LinkedList<T>.", exception.Message);
        }

        [Fact]
        public void TestAddAfterNullExceptionForExistingNode()
        {
            LinkedListNode<int> node = null;
            LinkedListNode<int> newNode = null;
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            var exception = Assert.Throws<ArgumentNullException>(() => list.AddAfter(node, newNode));
            Assert.Equal("Node is null.", exception.Message);
        }

        [Fact]
        public void TestAddAfterNullExceptionForNewNode()
        {
            LinkedListNode<int> node = new LinkedListNode<int>(2);
            LinkedListNode<int> newNode = null;
            var list = new LinkedList<int>();
            list.AddLast(node);
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            var exception = Assert.Throws<ArgumentNullException>(() => list.AddAfter(node, newNode));
            Assert.Equal("Node is null.", exception.Message);
        }

        [Fact]
        public void TestAddAfterNodeNotExistingInListException()
        {
            var node = new LinkedListNode<int>(2);
            var newNode = new LinkedListNode<int>(10);
            var list1 = new LinkedList<int>();
            list1.AddLast(3);
            list1.AddLast(8);

            var list2 = new LinkedList<int>();

            var exception = Assert.Throws<InvalidOperationException>(() => list1.AddAfter(node, newNode));
            Assert.Equal("Node is not in the current LinkedList<T>.", exception.Message);
        }

        [Fact]
        public void TestAddAfterNodeBelongingToAnotherListException()
        {
            var node = new LinkedListNode<int>(2);
            var newNode = new LinkedListNode<int>(2);
            var list1 = new LinkedList<int>();
            list1.AddLast(3);
            list1.AddLast(8);
            list1.AddLast(newNode);

            var list2 = new LinkedList<int>();
            list2.AddLast(node);

            var exception = Assert.Throws<InvalidOperationException>(() => list2.AddAfter(node, newNode));
            Assert.Equal("Node belongs to another LinkedList<T>.", exception.Message);
        }

        [Fact]
        public void TestRemoveNullException()
        {
            LinkedListNode<int> linkedListNode = null;
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(5);

            var exception = Assert.Throws<ArgumentNullException>(() => list.Remove(linkedListNode));
            Assert.Equal("Node is null.", exception.Message);
        }

        [Fact]
        public void TestRemoveNodeNotExistingInListException()
        {
            var linkedListNode = new LinkedListNode<int>(2);
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(8);

            var exception = Assert.Throws<InvalidOperationException>(() => list.Remove(linkedListNode));
            Assert.Equal("Node is not in the current LinkedList<T>.", exception.Message);
        }

        [Fact]
        public void TestRemoveFirstEmptyListException()
        {
            var list = new LinkedList<int>();

            var exception = Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
            Assert.Equal("The list is empty.", exception.Message);
        }
    }
}
