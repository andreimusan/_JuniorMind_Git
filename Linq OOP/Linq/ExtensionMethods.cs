using System;
using System.Collections.Generic;

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
    }
}
