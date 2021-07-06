using System;
using System.Collections.Generic;

namespace LinqExercitii
{
    public class Stock<TKey, TValue>
    {
        private readonly Dictionary<string, List<Product>> stock;

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

        public void RemoveProduct(string category, Product product, Action<string> lowStockNotification)
        {
            if (lowStockNotification == null || !stock.ContainsKey(category))
            {
                return;
            }

            bool returnValue = stock[category].Remove(product);

            if (!returnValue)
            {
                return;
            }

            lowStockNotification(category);
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
