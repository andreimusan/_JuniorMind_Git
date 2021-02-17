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
            get => base[index];
            set
            {
                if (IsSorted(index, value))
                {
                    base[index] = value;
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
            EnsureCapacity();
            ShiftRight(index);
            if (IsSorted(index, element))
            {
                base[index] = element;
            }
            else
            {
                ShiftLeft(index);
            }
        }

        private void SortArray()
        {
            for (int i = Count - 1; i > 0; i--)
            {
                if (base[i] < base[i - 1])
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
            int temp = base[firstIndex];
            base[firstIndex] = base[secondIndex];
            base[secondIndex] = temp;
        }

        private bool IsSorted(int index, int element)
        {
            if (index == 0 && element <= base[index + 1])
            {
                return true;
            }
            else if (index == Count && Count > 0 && element >= base[index - 1])
            {
                return true;
            }
            else if (index > 0 && index < Count && base[index - 1] <= element && element <= base[index + 1])
            {
                return true;
            }

            return false;
        }
    }
}
