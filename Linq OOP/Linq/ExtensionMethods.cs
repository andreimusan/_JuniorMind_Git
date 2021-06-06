﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public static class ExtensionMethods
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(Convert.ToString(predicate), "Predicate is null.");
            }

            foreach (TSource element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(Convert.ToString(predicate), "Predicate is null.");
            }

            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("No element was found.");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (selector == null)
            {
                throw new ArgumentNullException(Convert.ToString(selector), "Selector is null.");
            }

            IEnumerable<TResult> SelectImplementation()
            {
                foreach (TSource element in source)
                {
                    yield return selector(element);
                }
            }

            return SelectImplementation();
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (selector == null)
            {
                throw new ArgumentNullException(Convert.ToString(selector), "Selector is null.");
            }

            IEnumerable<TResult> SelectManyImplementation()
            {
                foreach (TSource element in source)
                {
                    foreach (TResult subelement in selector(element))
                    {
                        yield return subelement;
                    }
                }
            }

            return SelectManyImplementation();
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(Convert.ToString(predicate), "Predicate is null.");
            }

            IEnumerable<TSource> WhereImplementation()
            {
                foreach (TSource element in source)
                {
                    if (predicate(element))
                    {
                        yield return element;
                    }
                }
            }

            return WhereImplementation();
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(keySelector), "KeySelector is null.");
            }

            if (elementSelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(elementSelector), "ElementSelector is null.");
            }

            Dictionary<TKey, TElement> d = new Dictionary<TKey, TElement>();

            foreach (TSource element in source)
            {
                d.Add(keySelector(element), elementSelector(element));
            }

            return d;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null)
            {
                throw new ArgumentNullException(Convert.ToString(first), "The first sequence is null.");
            }

            if (second == null)
            {
                throw new ArgumentNullException(Convert.ToString(second), "The second sequence is null.");
            }

            IEnumerable<TResult> ZipImplementation()
            {
                using var e1 = first.GetEnumerator();
                using var e2 = second.GetEnumerator();
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return resultSelector(e1.Current, e2.Current);
                }
            }

            return ZipImplementation();
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            if (func == null)
            {
                throw new ArgumentNullException(Convert.ToString(func), "Function is null.");
            }

            TAccumulate result = seed;
            foreach (var element in source)
            {
                result = func(result, element);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {

            if (outer == null)
            {
                throw new ArgumentNullException(Convert.ToString(outer), "Outer is null.");
            }

            if (inner == null)
            {
                throw new ArgumentNullException(Convert.ToString(inner), "Inner is null.");
            }

            if (outerKeySelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(outerKeySelector), "OuterKeySelector is null.");
            }

            if (innerKeySelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(innerKeySelector), "InnerKeySelector is null.");
            }

            if (resultSelector == null)
            {
                throw new ArgumentNullException(Convert.ToString(resultSelector), "ResultSelector is null.");
            }

            IEnumerable<TResult> JoinImplementation()
            {
                var lookup = inner.ToLookup(innerKeySelector);
                foreach (var outerElement in outer)
                {
                    var key = outerKeySelector(outerElement);
                    foreach (var innerElement in lookup[key])
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }

            return JoinImplementation();
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), "Source is null.");
            }

            IEnumerable<TSource> DistinctImplementation()
            {
                HashSet<TSource> elements = new HashSet<TSource>(comparer);
                foreach (var item in source)
                {
                    if (elements.Add(item))
                    {
                        yield return item;
                    }
                }
            }

            return DistinctImplementation();
        }
    }
}
