using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class NewComparer<TSource, TKey> : IComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;
        internal NewComparer(Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer ?? Comparer<TKey>.Default;
        }

        public int Compare(TSource x, TSource y) => comparer.Compare(keySelector(x), keySelector(y));
    }
}
