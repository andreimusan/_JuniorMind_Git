using System;
using System.Collections.Generic;

namespace LinqExercitii
{
    public class Stock<TKey, TValue>
    {
        private readonly Dictionary<string, List<Product>> stock;
        private readonly int firstThreshold = 10;
        private readonly int secondThreshold = 5;
        private readonly int thirdThreshold = 2;

        public Stock()
        {
            this.stock = new Dictionary<string, List<Product>>();
        }

        public void AddProduct(string category, Product product)
        {
            if (stock.ContainsKey(category))
            {
                stock[category].Add(product);
            }
            else
            {
                stock.Add(category, new List<Product> { product });
            }
        }

        public void RemoveProduct(string category, Product product, Action<string, int> notification)
        {
            if (notification == null || !stock.ContainsKey(category))
            {
                return;
            }

            bool returnValue = stock[category].Remove(product);

            if (!returnValue)
            {
                return;
            }

            if (stock[category].Count <= thirdThreshold)
            {
                notification(category, thirdThreshold);
            }
            else if (stock[category].Count <= secondThreshold)
            {
                notification(category, secondThreshold);
            }
            else if (stock[category].Count <= firstThreshold)
            {
                notification(category, firstThreshold);
            }
        }

        public int GetCategoryCount(string category)
        {
            CheckExistingCategory(category);

            return stock[category].Count;
        }

        public int GetStockCount()
        {
            return stock.Count;
        }

        private void CheckExistingCategory(string category)
        {
            if (stock.ContainsKey(category))
            {
                return;
            }

            throw new ArgumentNullException(category, "nameof(category) does not exist");
        }
    }
}
