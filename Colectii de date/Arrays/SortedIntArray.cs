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
                int temp = base[index];
                base[index] = value;
                if (!IsSorted())
                {
                    base[index] = temp;
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
            base.Insert(index, element);
            if (!IsSorted())
            {
                RemoveAt(index);
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

        private bool IsSorted()
        {
            if (Count == 0 || Count == 1)
            {
                return true;
            }

            for (int i = 0; i < Count - 1; i++)
            {
                if (base[i] > base[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
