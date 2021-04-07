using System;
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
    }
}
