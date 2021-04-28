using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class Dictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private readonly List<BucketElement<TKey, TValue>> bucketslist = new List<BucketElement<TKey, TValue>>();

        public Dictionary(int capacity)
        {
            buckets = new int[capacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }
        }

        public IEqualityComparer<TKey> Comparer { get; }

        public int Count { get; protected set; }

        public TValue this[TKey key]
        {
            get
            {
                int index = FindKey(key);
                if (index >= 0)
                {
                    return bucketslist[index].Value;
                }

                return default;
            }

            set
            {
                int index = FindKey(key);
                if (index >= 0)
                {
                    bucketslist[index].Value = value;
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            int hashCode = key.GetHashCode();
            int targetBucket = hashCode % buckets.Length;

            var element = new BucketElement<TKey, TValue>(key, value);
            bucketslist.Add(element);
            bucketslist[Count].Next = buckets[targetBucket];

            buckets[targetBucket] = Count;
            Count++;
        }

        private int FindKey(TKey key)
        {
            if (buckets != null)
            {
                int hashCode = key.GetHashCode();
                for (var i = buckets[hashCode % buckets.Length]; i >= 0; i = bucketslist[i].Next)
                {
                    if (Comparer<TKey>.Default.Compare(bucketslist[i].Key, key) == 0)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
