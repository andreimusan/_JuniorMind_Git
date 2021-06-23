﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public static class ExtensionMethods
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));

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
            CheckForNull(source, nameof(source));

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
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));

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
            CheckForNull(source, nameof(source));
            CheckForNull(selector, nameof(selector));

            foreach (TSource element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(selector, nameof(selector));

            foreach (TSource element in source)
            {
                foreach (TResult subelement in selector(element))
                {
                    yield return subelement;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(predicate, nameof(predicate));

            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));
            CheckForNull(elementSelector, nameof(elementSelector));

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
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));

            using var e1 = first.GetEnumerator();
            using var e2 = second.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return resultSelector(e1.Current, e2.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(func, nameof(func));

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
            CheckForNull(outer, nameof(outer));
            CheckForNull(inner, nameof(inner));
            CheckForNull(outerKeySelector, nameof(outerKeySelector));
            CheckForNull(innerKeySelector, nameof(innerKeySelector));
            CheckForNull(resultSelector, nameof(resultSelector));

            foreach (var outerElement in outer)
            {
                foreach (var innerElement in inner)
                {
                    if (EqualityComparer<TKey>.Default.Equals(outerKeySelector(outerElement), innerKeySelector(innerElement)))
                    {
                        yield return resultSelector(outerElement, innerElement);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            CheckForNull(source, nameof(source));

            HashSet<TSource> elements = new HashSet<TSource>(comparer);
            foreach (var item in source)
            {
                if (elements.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));

            HashSet<TSource> elements = new HashSet<TSource>(first, comparer);
            elements.UnionWith(second);

            return elements;
        }

        public static IEnumerable<TSource> Intersect<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));

            HashSet<TSource> elements = new HashSet<TSource>(first, comparer);
            elements.IntersectWith(second);

            return elements;
        }

        public static IEnumerable<TSource> Except<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            CheckForNull(first, nameof(first));
            CheckForNull(second, nameof(second));

            HashSet<TSource> elements = new HashSet<TSource>(first, comparer);
            elements.ExceptWith(second);

            return elements;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));
            CheckForNull(elementSelector, nameof(elementSelector));

            return source.GroupByImpl(keySelector, elementSelector, comparer)
                 .Select(group => resultSelector(group.Key, group));
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            CheckForNull(source, nameof(source));
            CheckForNull(keySelector, nameof(keySelector));

            comparer ??= Comparer<TKey>.Default;

            List<TSource> list = source.ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (comparer.Compare(keySelector(list[j]), keySelector(list[j + 1])) < 0)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return (IOrderedEnumerable<TSource>)list;
        }

        private static IEnumerable<IGrouping<TKey, TElement>> GroupByImpl<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            var lookup = source.ToLookup(keySelector, elementSelector, comparer);
            foreach (var result in lookup)
            {
                yield return result;
            }
        }

        private static void CheckForNull<T>(T source, string sourceName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(Convert.ToString(source), sourceName);
            }
        }
    }
}
