using System;
using System.Collections;
using System.Collections.Generic;

namespace Arrays
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private BucketElement<TKey, TValue>[] elements = new BucketElement<TKey, TValue>[] { };
        private int freeIndex = -1;

        public Dictionary(int capacity)
        {
            buckets = new int[capacity];
            Array.Fill(buckets, -1);
        }

        public IEqualityComparer<TKey> Comparer => EqualityComparer<TKey>.Default;

        public int Count { get; protected set; }

        public bool IsReadOnly { get; }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();

                foreach (var elem in this)
                {
                    keys.Add(elem.Key);
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();

                foreach (var elem in this)
                {
                    values.Add(elem.Value);
                }

                return values;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                ExceptionForArgumentNull(key);
                ExceptionForKeyNotFound(key);
                int index = FindKey(key);
                if (index >= 0)
                {
                    return elements[index].Value;
                }

                throw new KeyNotFoundException("Key is not found.");
            }

            set
            {
                ExceptionForArgumentNull(key);
                int index = FindKey(key);

                try
                {
                    elements[index].Value = value;
                }
                catch
                {
                    throw new KeyNotFoundException("Key is not found.");
                }
                finally
                {
                    if (index < 0)
                    {
                        Add(key, value);
                    }
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            ExceptionForArgumentNull(key);
            ArgumentExceptionForExistingKey(key);

            int targetBucket = TargetBucket(key);

            var element = new BucketElement<TKey, TValue>(key, value);

            if (freeIndex == -1)
            {
                Array.Resize(ref elements, elements.Length + 1);
                elements[^1] = element;
                elements[Count].Next = buckets[targetBucket];
                buckets[targetBucket] = Count;
            }
            else
            {
                int newFreeIndex = elements[freeIndex].Next;
                elements[freeIndex] = element;
                elements[freeIndex].Next = buckets[targetBucket];
                buckets[targetBucket] = freeIndex;
                freeIndex = newFreeIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(buckets, -1);
            elements = new BucketElement<TKey, TValue>[] { };
            freeIndex = -1;
            Count = 0;
        }

        public bool ContainsKey(TKey key)
        {
            ExceptionForArgumentNull(key);
            return FindKey(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var elem in elements)
            {
                if (elem != null && EqualityComparer<TValue>.Default.Equals(elem.Value, value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => ContainsKey(item.Key) && ContainsValue(item.Value);

        public bool Remove(TKey key)
        {
            ExceptionForArgumentNull(key);

            if (buckets == null)
            {
                return false;
            }

            int targetBucket = TargetBucket(key);
            int last = -1;
            for (var i = buckets[targetBucket]; i >= 0; last = i, i = elements[i].Next)
            {
                if (Comparer.Equals(elements[i].Key, key))
                {
                    if (last < 0)
                    {
                        buckets[targetBucket] = elements[i].Next;
                    }
                    else
                    {
                        elements[last].Next = elements[i].Next;
                    }

                    int oldFreeIndex = freeIndex;
                    freeIndex = i;
                    elements[freeIndex].Next = oldFreeIndex;

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public bool TryGetValue(TKey key, out TValue value)
        {
            int findKey = FindKey(key);

            if (findKey != -1)
            {
                value = elements[findKey].Value;
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
                if (elements[i] != null)
                {
                    array[i + arrayIndex] = new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            bool validElement = true;

            for (int i = 0; i < Count; i++)
            {
                for (int j = freeIndex; j != -1; j = elements[freeIndex].Next)
                {
                    if (elements[i] == elements[j])
                    {
                        validElement = false;
                    }
                }

                if (validElement)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        private int TargetBucket(TKey key)
        {
            int hashCode = Math.Abs(key.GetHashCode());
            return hashCode % buckets.Length;
        }

        private int FindKey(TKey key)
        {
            if (buckets != null)
            {
                for (var i = buckets[TargetBucket(key)]; i >= 0; i = elements[i].Next)
                {
                    if (Comparer.Equals(elements[i].Key, key))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private void ExceptionForArgumentNull(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(Convert.ToString(key), "Key is null.");
            }
        }

        private void ExceptionForKeyNotFound(TKey key)
        {
            if (FindKey(key) == -1)
            {
                throw new KeyNotFoundException("Key is not found.");
            }
        }

        private void ArgumentExceptionForExistingKey(TKey key)
        {
            if (FindKey(key) != -1)
            {
                throw new ArgumentException("An element with the same key already exists.");
            }
        }
    }
}
