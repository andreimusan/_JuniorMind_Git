using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Arrays
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private readonly BucketElement<TKey, TValue>[] elements;
        private int freeIndex = -1;

        public Dictionary(int capacity)
        {
            buckets = new int[capacity];
            Array.Fill(buckets, -1);

            elements = new BucketElement<TKey, TValue>[capacity];
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
                int index = FindKey(key, out _);
                if (index >= 0)
                {
                    return elements[index].Value;
                }

                throw new KeyNotFoundException("Key is not found.");
            }

            set
            {
                ExceptionForArgumentNull(key);
                int index = FindKey(key, out _);

                if (index >= 0)
                {
                    elements[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            ExceptionForArgumentNull(key);
            ArgumentExceptionForExistingKey(key);

            int targetBucket = TargetBucket(key);
            int index;

            var element = new BucketElement<TKey, TValue>(key, value);

            if (freeIndex == -1)
            {
                index = Count;
            }
            else
            {
                index = freeIndex;
                freeIndex = elements[freeIndex].Next;
            }

            elements[index] = element;
            elements[index].Next = buckets[targetBucket];
            buckets[targetBucket] = index;

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(buckets, -1);
            Array.Fill(elements, null);
            freeIndex = -1;
            Count = 0;
        }

        public bool ContainsKey(TKey key)
        {
            ExceptionForArgumentNull(key);
            return FindKey(key, out _) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var elem in this)
            {
                if (EqualityComparer<TValue>.Default.Equals(elem.Value, value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            ExceptionForArgumentNull(item.Key);
            var index = FindKey(item.Key, out _);
            return index >= 0 && EqualityComparer<TValue>.Default.Equals(elements[index].Value, item.Value);
        }

        public bool Remove(TKey key)
        {
            ExceptionForArgumentNull(key);

            if (buckets == null)
            {
                return false;
            }

            int index = FindKey(key, out int last);
            if (index >= 0)
            {
                RemoveElement(key, index, last);
                return true;
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            ExceptionForArgumentNull(item.Key);

            if (buckets == null)
            {
                return false;
            }

            int index = FindKey(item.Key, out int last);
            if (index >= 0 && EqualityComparer<TValue>.Default.Equals(elements[index].Value, item.Value))
            {
                RemoveElement(item.Key, index, last);
                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int findKey = FindKey(key, out _);

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

            int index = 0;
            foreach (var elem in this)
            {
                array[index + arrayIndex] = new KeyValuePair<TKey, TValue>(elem.Key, elem.Value);
                index++;
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
                if (!IsElementFree(i))
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

        private int FindKey(TKey key, out int last)
        {
            last = -1;

            for (var i = buckets[TargetBucket(key)]; i >= 0; last = i, i = elements[i].Next)
            {
                if (Comparer.Equals(elements[i].Key, key))
                {
                    return i;
                }
            }

            return -1;
        }

        private void RemoveElement(TKey key, int currentindex, int prevIndex)
        {
            if (prevIndex < 0)
            {
                buckets[TargetBucket(key)] = elements[currentindex].Next;
            }
            else
            {
                elements[prevIndex].Next = elements[currentindex].Next;
            }

            int oldFreeIndex = freeIndex;
            freeIndex = currentindex;
            elements[freeIndex].Next = oldFreeIndex;

            Count--;
        }

        private bool IsElementFree(int index)
        {
            for (int j = freeIndex; j != -1; j = elements[freeIndex].Next)
            {
                if (elements[index] == elements[j])
                {
                    return true;
                }
            }

            return false;
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
            if (FindKey(key, out _) == -1)
            {
                throw new KeyNotFoundException("Key is not found.");
            }
        }

        private void ArgumentExceptionForExistingKey(TKey key)
        {
            if (FindKey(key, out _) != -1)
            {
                throw new ArgumentException("An element with the same key already exists.");
            }
        }
    }
}
