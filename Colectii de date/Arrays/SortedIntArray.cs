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
                if (ElementAt(index - 1, value) <= value && value <= ElementAt(index + 1, value))
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
            if (ElementAt(index - 1, element) <= element && element <= ElementAt(index, element))
            {
                base.Insert(index, element);
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

        private int ElementAt(int index, int defaultValue)
        {
            return index < 0 || index >= Count ? defaultValue : base[index];
        }
    }
}
