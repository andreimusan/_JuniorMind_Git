using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class ObjectArray : IEnumerator
    {
        public object[] Array;

        readonly int length;
        int position = -1;

        public ObjectArray(object[] list, int count)
        {
            Array = list;
            length = count;
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
            return position < length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
