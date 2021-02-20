using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class List<T> : IEnumerable<T>
    {
        private T[] array;

        public List()
        {
            const int initialLength = 4;
            array = new T[initialLength];
        }

        public int Count { get; protected set; }

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public virtual void Add(T element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(object element) => Array.IndexOf(array, element, 0, Count) != -1;

        public int IndexOf(object element) => Array.IndexOf(array, element, 0, Count);

        public virtual void Insert(int index, T element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear() => Count = 0;

        public void Remove(int element) => ShiftLeft(IndexOf(element));

        public void RemoveAt(int index) => ShiftLeft(index);

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
