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
                if (IsStillSorted(index, value))
                {
                    array[index] = value;
                }
            }
        }

        public override void Add(int element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, int element)
        {
            if (IsStillSorted(index, element))
            {
                base.Insert(index, element);
            }
        }

        private void SortArray()
        {
            for (int i = Count - 1; i > 0; i--)
            {
                if (array[i] < array[i - 1])
                {
                    Swap(i, i - 1);
                }
                else
                {
                    return;
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        private bool IsStillSorted(int index, int element)
        {
            if (index == 0 && element < array[index + 1])
            {
                return true;
            }
            else if (index == Count && Count > 0 && element > array[index - 1])
            {
                return true;
            }
            else if (index > 0 && index < Count && element > array[index - 1] && element < array[index + 1])
            {
                return true;
            }

            return false;
        }
    }
}
