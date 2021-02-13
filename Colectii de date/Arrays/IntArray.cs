using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;
        private int count;

        public IntArray()
        {
            const int initialLength = 4;
            array = new int[initialLength];
            count = 0;
        }

        public void Add(int element)
        {
            EnsureCapacity();
            array[count] = element;
            count++;
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < count)
            {
                array[index] = element;
            }
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(array, element) != -1 &&
                Array.IndexOf(array, element) <= count;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element) <= count ? Array.IndexOf(array, element) : -1;
        }

        public void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
        }

        public void Clear()
        {
            count = 0;
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
            if (count == array.Length - 1)
            {
                const int two = 2;
                Array.Resize(ref array, array.Length * two);
            }
        }

        private void ShiftRight(int index)
        {
            count++;
            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < count; i++)
            {
                array[i] = array[i + 1];
            }

            count--;
        }
    }
}
