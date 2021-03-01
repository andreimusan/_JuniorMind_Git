using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList()
            : base()
        {
        }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                if (ElementAt(index - 1, value).CompareTo(value) <= 0 && value.CompareTo(ElementAt(index + 1, value)) <= 0)
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(T item)
        {
            base.Add(item);
            SortArray();
        }

        public override void Insert(int index, T item)
        {
            if (ElementAt(index - 1, item).CompareTo(item) <= 0 && item.CompareTo(ElementAt(index, item)) <= 0)
            {
                base.Insert(index, item);
            }
        }

        private void SortArray()
        {
            for (int i = Count - 1; i > 0; i--)
            {
                if (base[i].CompareTo(base[i - 1]) < 0)
                {
                    T a = base[i];
                    T b = base[i - 1];
                    Swap(ref a, ref b);
                    base[i] = a;
                    base[i - 1] = b;
                }
                else
                {
                    return;
                }
            }
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private T ElementAt(int index, T defaultValue)
        {
            return index < 0 || index >= Count ? defaultValue : base[index];
        }
    }
}
