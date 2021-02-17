using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            const int initialLength = 4;
            array = new int[initialLength];
        }

        public int Count { get; protected set; }

        public virtual int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(int element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public bool Contains(int element) => Array.IndexOf(array, element, 0, Count) != -1;

        public int IndexOf(int element) => Array.IndexOf(array, element, 0, Count);

        public virtual void Insert(int index, int element)
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

        protected void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Count--;
        }
    }
}
