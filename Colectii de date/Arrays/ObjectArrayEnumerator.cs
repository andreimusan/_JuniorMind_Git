using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ObjectArrayEnumerator : IEnumerator
    {
        public ObjectArray Array;

        int position = -1;

        public ObjectArrayEnumerator(ObjectArray array)
        {
            Array = array;
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public object Current
        {
            get => Array[position];
        }

        public bool MoveNext()
        {
            if (position >= Array.Count - 1)
            {
                return false;
            }

            position++;
            return true;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
