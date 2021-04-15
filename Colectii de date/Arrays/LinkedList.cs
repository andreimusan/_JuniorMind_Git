using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class LinkedList<T>
    {
        public LinkedList()
        {
            First = null;
            Last = null;
        }

        public LinkedListNode<T> First { get; set; }

        public LinkedListNode<T> Last { get; set; }

        public int Count { get; private set; }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            ConnectToLastNode(node);
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectToLastNode(newNode);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            ConnectToFirstNode(node);
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectToFirstNode(newNode);
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
            {
                return;
            }

            ConnectAfterNode(node, newNode);
        }

        public void AddAfter(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
            {
                return;
            }

            ConnectAfterNode(node.Previous, newNode);
        }

        public void AddBefore(LinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                return;
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            ConnectAfterNode(node.Previous, newNode);
        }

        public void Clear()
        {
            Count = 0;
            First = null;
            Last = null;
        }

        public bool Contains(T item)
        {
            if (First == null)
            {
                return false;
            }

            LinkedListNode<T> tempNode = First;
            while (tempNode.Next != null)
            {
                if (Comparer<T>.Default.Compare(tempNode.Value, item) == 0)
                {
                    return true;
                }

                tempNode = tempNode.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(Convert.ToString(index), "Array is null.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(index), "Index was out of range. Must be positive.");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("The number of elements to copy is greater than the available space in the array.");
            }

            LinkedListNode<T> tempNode = First;
            for (int i = 0; i < Count; i++)
            {
                array[i + index] = tempNode.Value;
                tempNode = tempNode.Next;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            if (First == null)
            {
                return null;
            }

            LinkedListNode<T> tempNode = First;
            while (tempNode.Next != null)
            {
                if (Comparer<T>.Default.Compare(tempNode.Value, value) == 0)
                {
                    return tempNode;
                }

                tempNode = tempNode.Next;
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T value)
        {
            if (Last == null)
            {
                return null;
            }

            LinkedListNode<T> tempNode = Last;
            while (tempNode.Previous != null)
            {
                if (Comparer<T>.Default.Compare(tempNode.Value, value) == 0)
                {
                    return tempNode;
                }

                tempNode = tempNode.Previous;
            }

            return null;
        }

        private void ConnectToLastNode(LinkedListNode<T> currentNode)
        {
            if (Last == null)
            {
                First = currentNode;
            }
            else
            {
                currentNode.Previous = Last;
                Last.Next = currentNode;
            }

            Last = currentNode;

            currentNode.List = this;

            Count++;
        }

        private void ConnectToFirstNode(LinkedListNode<T> currentNode)
        {
            currentNode.Next = First;

            if (First == null)
            {
                Last = currentNode;
            }
            else
            {
                First.Previous = currentNode;
            }

            First = currentNode;

            currentNode.List = this;

            Count++;
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
    }
}
