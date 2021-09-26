using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqExercitii
{
    public struct ProductStruct
    {
        public string Name;
        public int Quantity;
    }

    public class FilterOperations
    {
        public static IEnumerable<Product> FilterProductWithOneFeature(ICollection<Product> products, ICollection<Feature> features)
        {
            var result = products.Where(p => features.Any(f => p.Features.Contains(f)));

            return result;
        }

        public static IEnumerable<Product> FilterProductWithAllFeatures(ICollection<Product> products, ICollection<Feature> features)
        {
            var result = products.Where(p => features.All(f => p.Features.Contains(f)));

            return result;
        }

        public static IEnumerable<Product> FilterProductWithNoFeature(ICollection<Product> products, ICollection<Feature> features)
        {
            var result = products.Where(p => !features.Any(f => p.Features.Contains(f)));

            return result;
        }

        public static IEnumerable<ProductStruct> MergeListsOfProducts(IEnumerable<ProductStruct> firstList, IEnumerable<ProductStruct> secondList)
        {
            var result = firstList.Concat(secondList).
                GroupBy(g => g.Name).
                Select(l => new ProductStruct
                {
                    Name = l.Key,
                    Quantity = l.Sum(q => q.Quantity)
                });

            return result;
        }

        public static IEnumerable<TestResults> MaxScore(IEnumerable<TestResults> list)
        {
            var result = list.GroupBy(p => new { p.FamilyId, p.Id }).Select(s => s.Aggregate((max, value) => value.Score > max.Score ? value : max));

            return result;
        }

        public static IEnumerable<string> MostUsedWords(string text)
        {
            if (text == null)
            {
                return null;
            }

            var words = text.Split(new[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var result = words.GroupBy(x => x.ToLower()).Where(n => n.Count() > 1).OrderByDescending(n => n.Count()).Select(w => w.Key).Take(3);

            return result;
        }
    }
}
