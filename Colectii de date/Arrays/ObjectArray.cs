using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ObjectArray : IEnumerator
    {
        public object[] Array;

        int position = -1;

        public ObjectArray(object[] list)
        {
            Array = list;
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
            position++;
            return position < Array.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
