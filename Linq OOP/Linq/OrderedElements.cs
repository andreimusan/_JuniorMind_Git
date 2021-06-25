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
        private readonly IComparer<TSource> firstComparer;

        internal OrderedElements(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            this.source = source;
            this.firstComparer = comparer;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (keySelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(keySelector), "keySelector is null");
            }

            var secondComparer = new OrderingComparer<TSource, TKey>(keySelector, comparer);

            return new OrderedElements<TSource>(source, new DoubleComparer<TSource>(firstComparer, secondComparer));
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
                    if (firstComparer.Compare(list[i], minElement) < 0)
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
