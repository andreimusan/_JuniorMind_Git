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

        public int Count { get; private set; }

        public void Add(int element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < Count)
            {
                array[index] = element;
            }
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(array, element) != -1 &&
                Array.IndexOf(array, element) <= Count;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element) <= Count ? Array.IndexOf(array, element) : -1;
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
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

        private void EnsureCapacity()
        {
            if (Count == array.Length)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }

        private void ShiftRight(int index)
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
