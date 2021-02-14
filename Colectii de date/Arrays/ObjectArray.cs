using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ObjectArray
    {
        protected object[] array;

        public ObjectArray()
        {
            const int initialLength = 4;
            array = new object[initialLength];
        }

        public int Count { get; protected set; }

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(object element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return Array.IndexOf(array, element) != -1 &&
                Array.IndexOf(array, element) <= Count;
        }

        public int IndexOf(object element) => Array.IndexOf(array, element) <= Count ? Array.IndexOf(array, element) : -1;

        public virtual void Insert(int index, object element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(object element)
        {
            if (Contains(element))
            {
                ShiftLeft(IndexOf(element));
            }
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
        }

        protected void EnsureCapacity()
        {
            if (Count == array.Length)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }

        protected void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            Count++;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count; i++)
            {
                array[i] = array[i + 1];
            }

            Count--;
        }
    }
}
