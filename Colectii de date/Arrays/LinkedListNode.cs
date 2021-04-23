using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value) => Value = value;

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }

        public LinkedList<T> List { get; internal set; }
    }
}
