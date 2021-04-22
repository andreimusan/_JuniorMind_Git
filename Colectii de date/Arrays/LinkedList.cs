﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedList()
        {
            First = null;
        }

        public LinkedListNode<T> First { get; set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public void AddLast(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeBelongsToAnotherList(node);
            ConnectToLastNode(node);
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectToLastNode(newNode);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeBelongsToAnotherList(node);
            ConnectToFirstNode(node);
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectToFirstNode(newNode);
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            ExceptionForArgumentNull(newNode);

            ExceptionForNodeNotExistingInList(node);
            ExceptionForNodeBelongsToAnotherList(newNode);

            ConnectAfterNode(node, newNode);
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            ExceptionForArgumentNull(node);
            ExceptionForArgumentNull(newNode);

            ExceptionForNodeNotExistingInList(node);
            ExceptionForNodeBelongsToAnotherList(newNode);

            ConnectAfterNode(node.Previous, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node.Previous, newNode);
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Count = 0;
            First = null;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> currentNode = First;
            for (int i = 0; i < Count; i++)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, item) == 0)
                {
                    return true;
                }

                currentNode = currentNode.Next;
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

            LinkedListNode<T> currentNode = First;
            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> currentNode = First;
            for (int i = 0; i < Count; i++)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            LinkedListNode<T> currentNode = First.Previous;
            for (int i = Count - 1; i >= 0; i--)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, value) == 0)
                {
                    return currentNode;
                }

                currentNode = currentNode.Previous;
            }

            return null;
        }

        public void Remove(LinkedListNode<T> node)
        {
            ExceptionForArgumentNull(node);
            ExceptionForNodeNotExistingInList(node);

            DisconnectNode(node);
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> nodeToRemove = Find(item);
            if (nodeToRemove != null)
            {
                DisconnectNode(nodeToRemove);
                return true;
            }

            return false;
        }

        public void RemoveFirst()
        {
            ExceptionForEmptyList();

            First = First.Next;
            Count--;
        }

        public void RemoveLast()
        {
            ExceptionForEmptyList();

            First.Previous = First.Previous.Previous;
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            for (int i = 0; i < Count; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        private void ConnectToLastNode(LinkedListNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                First.Previous = newNode;
                First.Next = newNode;
            }
            else
            {
                First.Previous.Next = newNode;
                newNode.Next = First;
                newNode.Previous = First.Previous;
                First.Previous = newNode;
            }

            Count++;
        }

        private void ConnectToFirstNode(LinkedListNode<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                First.Previous = newNode;
                First.Next = newNode;
            }
            else
            {
                newNode.Next = First;
                newNode.Previous = First.Previous;
                First.Previous.Next = newNode;
                First.Previous = newNode;
                First = newNode;
            }

            Count++;
        }

        private LinkedListNode<T> FindNode(LinkedListNode<T> node)
        {
            LinkedListNode<T> currentNode = First;
            for (int i = 0; i < Count; i++)
            {
                if (Comparer<T>.Default.Compare(currentNode.Value, node.Value) == 0 && currentNode.Previous == node.Previous && currentNode.Next == node.Next)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        private void ConnectAfterNode(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            LinkedListNode<T> temp = node.Next;
            node.Next = newNode;
            newNode.Previous = node;
            newNode.Next = temp;
            temp.Previous = newNode;
            Count++;
        }

        private void DisconnectNode(LinkedListNode<T> node)
        {
            if (node.Next == First)
            {
                First.Previous = node.Previous;
            }
            else
            {
                node.Next.Previous = node.Previous;
            }

            if (node.Previous == First.Previous)
            {
                First = node.Next;
            }
            else
            {
                node.Previous.Next = node.Next;
            }

            Count--;
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
            if (First == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }
    }
}
