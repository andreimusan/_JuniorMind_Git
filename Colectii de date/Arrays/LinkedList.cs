using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class LinkedList<T> : ICollection<T>
    {
        private readonly LinkedListNode<T> sentinel;

        public LinkedList()
        {
            sentinel = new LinkedListNode<T>(default);
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            sentinel.List = this;
        }

        public int Count { get; private set; }

        public LinkedListNode<T> First => sentinel.Next;

        public LinkedListNode<T> Last => sentinel.Previous;

        public bool IsReadOnly { get; }

        public void AddLast(LinkedListNode<T> node)
        {
            AddBefore(sentinel, node);
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddBefore(sentinel, newNode);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            AddAfter(sentinel, node);
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddAfter(sentinel, newNode);
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            ExceptionForArgumentNull(newNode);

            ExceptionForNodeNotExistingInList(node);
            ExceptionForNodeBelongsToAnotherList(newNode);

            newNode.Next = node.Next;
            newNode.Previous = node;
            node.Next.Previous = newNode;
            node.Next = newNode;
            newNode.List = this;

            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            var newNode = new LinkedListNode<T>(value);
            AddAfter(node, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            AddAfter(node.Previous, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            var newNode = new LinkedListNode<T>(value);
            AddAfter(node.Previous, newNode);
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            sentinel.List = null;
        }

        public bool Contains(T item)
        {
            for (var currentNode = sentinel.Next; currentNode != sentinel; currentNode = currentNode.Next)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(Convert.ToString(arrayIndex), "Array is null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(arrayIndex), "Index was out of range. Must be positive.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The number of elements to copy is greater than the available space in the array.");
            }

            int index = 0;
            for (var currentNode = sentinel.Next; currentNode != sentinel; currentNode = currentNode.Next)
            {
                array[index + arrayIndex] = currentNode.Value;
                index++;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            for (var currentNode = sentinel.Next; currentNode != sentinel; currentNode = currentNode.Next)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            for (var currentNode = sentinel.Previous; currentNode != sentinel; currentNode = currentNode.Previous)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }
            }

            return null;
        }

        public void Remove(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;

            Count--;
        }

        public bool Remove(T item)
        {
            var nodeToRemove = Find(item);
            if (nodeToRemove != null)
            {
                Remove(nodeToRemove);
                return true;
            }

            return false;
        }

        public void RemoveFirst()
        {
            ExceptionForEmptyList();

            Remove(sentinel.Next);
        }

        public void RemoveLast()
        {
            ExceptionForEmptyList();

            Remove(sentinel.Previous);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var currentNode = sentinel.Previous; currentNode != sentinel; currentNode = currentNode.Previous)
            {
                yield return currentNode.Value;
            }
        }

        private void ExceptionForArgumentNull(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(Convert.ToString(node), "Node is null.");
            }
        }

        private void ExceptionForNodeBelongsToAnotherList(LinkedListNode<T> node)
        {
            if (node.Previous != null || node.Next != null)
            {
                throw new InvalidOperationException("Node belongs to another LinkedList<T>.");
            }
        }

        private void ExceptionForNodeNotExistingInList(LinkedListNode<T> node = null)
        {
            if (node.List != this)
            {
                throw new InvalidOperationException("Node is not in the current LinkedList<T>.");
            }
        }

        private void ExceptionForEmptyList()
        {
            if (sentinel.Next == sentinel.Previous)
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }
    }
}
