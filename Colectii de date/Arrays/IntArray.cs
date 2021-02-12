using System;

namespace Arrays
{
    public class IntArray
    {
        private int[] array;
        private int validPosition;

        public IntArray()
        {
            const int arrayLength = 4;
            array = new int[arrayLength];
            validPosition = 0;
        }

        public void Add(int element)
        {
            const int two = 2;

            if (validPosition == array.Length - 1)
            {
                Array.Resize(ref array, array.Length * two);
                array[array.Length / two] = element;
                validPosition++;
            }
            else
            {
                array[validPosition] = element;
                validPosition++;
            }
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            if (index < array.Length)
            {
                array[index] = element;
            }
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(array, element) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
        }

        public void Clear()
        {
            const int arrayLength = 4;
            array = new int[arrayLength];
            validPosition = 0;
        }

        public void Remove(int element)
        {
            if (Array.IndexOf(array, element) != -1)
            {
                var index = Array.IndexOf(array, element);
                for (int i = index; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                Array.Resize(ref array, array.Length - 1);
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);
        }
    }
}
