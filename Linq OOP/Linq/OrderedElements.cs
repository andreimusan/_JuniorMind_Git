using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    public class OrderedElements<TSource> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> source;
        private readonly IComparer<TSource> comparer;

        internal OrderedElements(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            this.source = source;
            this.comparer = comparer;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            List<TSource> list = source.ToList();
            while (list.Count > 0)
            {
                TSource minElement = list[0];
                int minIndex = 0;

                for (int i = 1; i < list.Count; i++)
                {
                    if (comparer.Compare(list[i], minElement) < 0)
                    {
                        minElement = list[i];
                        minIndex = i;
                    }
                }

                list.RemoveAt(minIndex);

                yield return minElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
