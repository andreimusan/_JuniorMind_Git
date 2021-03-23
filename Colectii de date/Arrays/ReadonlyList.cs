using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ReadonlyList<T> : List<T>
    {
        public ReadonlyList()
            : base()
        {
        }

        public new bool IsReadOnly
        {
            get { return true; }
        }

        public override T this[int index]
        {
            get => base[index];
            set
            {
                ExceptionForReadonly();
                base[index] = value;
            }
        }

        public override void Add(T item)
        {
            ExceptionForReadonly();
            base.Add(item);
        }

        public override void Insert(int index, T item)
        {
            ExceptionForReadonly();
            base.Insert(index, item);
        }

        public override void Clear()
        {
            ExceptionForReadonly();
            base.Clear();
        }

        public override bool Remove(T item)
        {
            ExceptionForReadonly();
            base.Remove(item);
        }

        public override void RemoveAt(int index)
        {
            ExceptionForReadonly();
            base.RemoveAt(index);
        }

        private void ExceptionForReadonly()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Collection is read-only.");
            }
        }
    }
}
