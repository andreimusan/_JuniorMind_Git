using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    class DoubleComparer<TSource> : IComparer<TSource>
    {
        private readonly IComparer<TSource> firstComparer;
        private readonly IComparer<TSource> secondComparer;
        internal DoubleComparer(IComparer<TSource> firstComparer, IComparer<TSource> secondComparer)
        {
            this.firstComparer = firstComparer;
            this.secondComparer = secondComparer;
        }

        public int Compare(TSource x, TSource y)
        {
            int firstResult = firstComparer.Compare(x, y);
            return firstResult == 0 ? secondComparer.Compare(x, y) : firstResult;
        }
    }
}
