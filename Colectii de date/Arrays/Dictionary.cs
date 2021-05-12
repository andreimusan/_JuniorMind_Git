using System;
using System.Collections;
using System.Collections.Generic;

namespace Arrays
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private readonly List<BucketElement<TKey, TValue>> bucketslist = new List<BucketElement<TKey, TValue>>();
        private readonly List<int> freeIndex = new List<int> { -1 };
        private int freeCount;

        public Dictionary(int capacity)
        {
            buckets = new int[capacity];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }
        }

        public IEqualityComparer<TKey> Comparer => EqualityComparer<TKey>.Default;

        public int Count { get; protected set; }

        public bool IsReadOnly { get; }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();

                foreach (var elem in bucketslist)
                {
                    if (elem != null)
                    {
                        keys.Add(elem.Key);
                    }
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();

                foreach (var elem in bucketslist)
                {
                    if (elem != null)
                    {
                        values.Add(elem.Value);
                    }
                }

                return values;
            }
        }

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
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            int hashCode = key.GetHashCode();
            int targetBucket = hashCode % buckets.Length;

            var element = new BucketElement<TKey, TValue>(key, value);

            if (freeCount < 1)
            {
                bucketslist.Add(element);
                bucketslist[Count].Next = buckets[targetBucket];
                buckets[targetBucket] = Count;
            }
            else
            {
                bucketslist.Insert(freeIndex[0], element);
                bucketslist[freeIndex[0]].Next = buckets[targetBucket];
                buckets[targetBucket] = freeIndex[0];
                freeIndex.RemoveAt(0);
                freeCount--;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                bucketslist.Remove(bucketslist[i]);
            }

            Count = 0;
        }

        public bool ContainsKey(TKey key)
        {
            return FindKey(key) >= 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => ContainsKey(item.Key);

        public bool Remove(TKey key)
        {
            if (buckets == null)
            {
                return false;
            }

            int hashCode = key.GetHashCode();
            int targetBucket = hashCode % buckets.Length;
            int last = -1;
            for (var i = buckets[targetBucket]; i >= 0; last = i, i = bucketslist[i].Next)
            {
                if (Comparer.Equals(bucketslist[i].Key, key))
                {
                    if (last < 0)
                    {
                        buckets[targetBucket] = bucketslist[i].Next;
                    }
                    else
                    {
                        bucketslist[last].Next = bucketslist[i].Next;
                    }

                    bucketslist[i] = null;
                    freeIndex.Insert(0, i);
                    freeCount++;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (ContainsKey(key))
            {
                value = bucketslist[FindKey(key)].Value;
                return true;
            }
            else
            {
                value = (TValue)default;
                return false;
            }
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(Convert.ToString(arrayIndex), "Array is null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(arrayIndex), "Index was out of range. Must be positive.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The number of elements to copy is greater than the available space in the array.");
            }

            for (int i = 0; i < Count; i++)
            {
                if (bucketslist[i] != null)
                {
                    array[i + arrayIndex] = new KeyValuePair<TKey, TValue>(bucketslist[i].Key, bucketslist[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (bucketslist[i] != null)
                {
                    yield return new KeyValuePair<TKey, TValue>(bucketslist[i].Key, bucketslist[i].Value);
                }
            }
        }

        private int FindKey(TKey key)
        {
            if (buckets != null)
            {
                int hashCode = key.GetHashCode();
                int targetBucket = hashCode % buckets.Length;
                for (var i = buckets[targetBucket]; i >= 0; i = bucketslist[i].Next)
                {
                    if (Comparer.Equals(bucketslist[i].Key, key))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
