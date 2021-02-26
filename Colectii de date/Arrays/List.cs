using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class List<T> : IList<T>
    {
        private T[] list;

        public List()
        {
            const int initialLength = 4;
            list = new T[initialLength];
        }

        public int Count { get; protected set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            list[Count] = item;
            Count++;
        }

        public bool Contains(T item) => Array.IndexOf(list, item, 0, Count) != -1;

        public int IndexOf(T item) => Array.IndexOf(list, item, 0, Count);

        public virtual void Insert(int index, T item)
        {
            EnsureCapacity();
            ShiftRight(index);
            list[index] = item;
        }

        public void Clear() => Count = 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = list[i];
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                ShiftLeft(IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index) => ShiftLeft(index);

        protected void EnsureCapacity()
        {
            if (Count == list.Length)
            {
                const int two = 2;
                Array.Resize(ref list, list.Length * two);
            }
        }

        protected void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                list[i] = list[i - 1];
            }

            Count++;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count; i++)
            {
                list[i] = list[i + 1];
            }

            Count--;
        }
    }
}
