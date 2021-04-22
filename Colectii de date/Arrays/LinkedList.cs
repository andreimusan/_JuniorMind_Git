using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class LinkedList<T> : ICollection<T>
    {
        private LinkedListNode<T> sentinel;

        public LinkedList()
        {
            sentinel = new LinkedListNode<T>(default);
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public void AddLast(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeBelongsToAnotherList(node);
            ConnectAfterNode(sentinel.Previous, node);
            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(sentinel.Previous, newNode);
            Count++;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeBelongsToAnotherList(node);
            ConnectAfterNode(sentinel.Previous, node);
            sentinel = node;
            Count++;
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(sentinel.Previous, newNode);
            sentinel = newNode;
            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            ExceptionForArgumentNull(newNode);

            ExceptionForNodeNotExistingInList(node);
            ExceptionForNodeBelongsToAnotherList(newNode);

            ConnectAfterNode(node, newNode);
            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node, newNode);
            Count++;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            ExceptionForArgumentNull(newNode);

            ExceptionForNodeNotExistingInList(node);
            ExceptionForNodeBelongsToAnotherList(newNode);

            ConnectAfterNode(node.Previous, newNode);
            Count++;
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node.Previous, newNode);
            Count++;
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
        }

        public bool Contains(T item)
        {
            foreach (var nodeValue in this)
            {
                if (Comparer<T>.Default.Compare(nodeValue, item) == 0)
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
            foreach (var nodeValue in this)
            {
                array[index + arrayIndex] = nodeValue;
                index++;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> currentNode = sentinel;
            do
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }
            while (currentNode != sentinel);

            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> currentNode = sentinel.Previous;
            do
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Previous;
            }
            while (currentNode != sentinel.Previous);

            return null;
        }

        public void Remove(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            ConnectAfterNode(node.Previous, node.Next);
            Count--;
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> nodeToRemove = Find(item);
            if (nodeToRemove != null)
            {
                ConnectAfterNode(nodeToRemove.Previous, nodeToRemove.Next);
                Count--;
                return true;
            }

            return false;
        }

        public void RemoveFirst()
        {
            ExceptionForEmptyList();

            sentinel = sentinel.Next;
            ConnectAfterNode(sentinel.Previous.Previous, sentinel);
            Count--;
        }

        public void RemoveLast()
        {
            ExceptionForEmptyList();

            ConnectAfterNode(sentinel.Previous.Previous, sentinel);
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = sentinel;
            do
            {
                yield return current.Value;
                current = current.Next;
            }
            while (current != sentinel);
        }

        private LinkedListNode<T> FindNode(LinkedListNode<T> node)
        {
            LinkedListNode<T> currentNode = sentinel;
            do
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, node.Value) == 0 && currentNode.Previous == node.Previous && currentNode.Next == node.Next)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }
            while (currentNode != sentinel);

            return null;
        }

        private void ConnectAfterNode(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (Count == 0)
            {
                sentinel = newNode;
                sentinel.Previous = newNode;
                sentinel.Next = newNode;
            }
            else
            {
                LinkedListNode<T> temp = node.Next;
                node.Next = newNode;
                newNode.Previous = node;
                newNode.Next = temp;
                temp.Previous = newNode;
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
            if (FindNode(node) == null)
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
