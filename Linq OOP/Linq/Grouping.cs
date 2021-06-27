using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    class Grouping<TKey, TElement> : System.Linq.IGrouping<TKey, TElement>
    {
        private readonly IEnumerable<TElement> elements;
        public TKey Key { get; }

        public Grouping(TKey key, IEnumerable<TElement> elements)
        {
            Key = key;
            this.elements = elements;
        }

        public IEnumerator<TElement> GetEnumerator() => elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
