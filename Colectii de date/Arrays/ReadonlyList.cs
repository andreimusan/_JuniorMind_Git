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
            get => this[index];
            set
            {
                ExceptionForReadonly();
                readOnlyList[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => readOnlyList.GetEnumerator();

        public IEnumerator<T> GetEnumerator() => readOnlyList.GetEnumerator();

        public void Add(T item) => ExceptionForReadonly();

        public bool Contains(T item) => readOnlyList.Contains(item);

        public int IndexOf(T item) => readOnlyList.IndexOf(item);

        public void Insert(int index, T item) => ExceptionForReadonly();

        public void Clear() => ExceptionForReadonly();

        public void CopyTo(T[] array, int arrayIndex) => readOnlyList.CopyTo(array, arrayIndex);

        public bool Remove(T item)
        {
            ExceptionForReadonly();
            return readOnlyList.Remove(item);
        }

        public void RemoveAt(int index) => ExceptionForReadonly();

        private void ExceptionForReadonly()
        {
            throw new NotSupportedException("Collection is read-only.");
        }
    }
}
