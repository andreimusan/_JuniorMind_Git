using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    public class BucketElement<TKey, TValue>
    {
        public BucketElement(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int Next { get; set; }
    }
}
