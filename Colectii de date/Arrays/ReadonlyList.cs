using System;
using System.Collections;
using System.Collections.Generic;

namespace Arrays
{
    public class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> readOnlyList;

        public ReadOnlyList(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(Convert.ToString(list), "Array is null.");
            }

            readOnlyList = list;
        }

        public int Count { get; }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public T this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                ExceptionForReadonly();
                readOnlyList[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return readOnlyList[i];
            }
        }

        public void Add(T item)
        {
            ExceptionForReadonly();
        }

        public bool Contains(T item) => Array.IndexOf((T[])readOnlyList, item, 0, Count) != -1;

        public int IndexOf(T item) => Array.IndexOf((T[])readOnlyList, item, 0, Count);

        public void Insert(int index, T item) => ExceptionForReadonly();

        public void Clear() => ExceptionForReadonly();

        public void CopyTo(T[] array, int arrayIndex)
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
                array[i + arrayIndex] = readOnlyList[i];
            }
        }

        public bool Remove(T item)
        {
            ExceptionForReadonly();
            return false;
        }

        public void RemoveAt(int index) => ExceptionForReadonly();

        private void ExceptionForReadonly()
        {
            throw new NotSupportedException("Collection is read-only.");
        }
    }
}
