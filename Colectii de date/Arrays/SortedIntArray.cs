using System;

namespace Arrays
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray()
            : base()
        {
        }

        public override int this[int index]
        {
            get => array[index];
            set
            {
                array[index] = value;
                SortArray();
            }
        }

        public override void Add(int element)
        {
            EnsureCapacity();
            array[Count] = element;
            Count++;
            SortArray();
        }

        public override void Insert(int index, int element)
        {
            EnsureCapacity();
            ShiftRight(index);
            array[index] = element;
            SortArray();
        }

        private void SortArray()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(j, j + 1);
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
