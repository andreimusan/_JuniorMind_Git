using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public static class CombinationExtension
    {
        public static IEnumerable<IEnumerable<T>> GetSubsets<T>(this IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            }

            var element = collection.Take(1);
            var ignoreFirstSubsets = GetSubsets(collection.Skip(1));
            var subsets = ignoreFirstSubsets.Select(set => element.Concat(set));
            return subsets.Concat(ignoreFirstSubsets);
        }
    }
}
