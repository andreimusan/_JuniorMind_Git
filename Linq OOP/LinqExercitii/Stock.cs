using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercitii
{
    public class Stock<TKey, TValue>
    {
        private readonly Dictionary<string, List<Product>> stock;
        private readonly Action<object, string> lowStockNotification;
        private readonly int[] threshold = { 2, 5, 10 };

        public Stock(Action<object, string> lowStockNotification)
        {
            this.stock = new Dictionary<string, List<Product>>();
            this.lowStockNotification = lowStockNotification;
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

        public void RemoveProduct(string category, Product product)
        {
            if (!stock.ContainsKey(category))
            {
                return;
            }

            int oldStockCount = stock[category].Count;

            bool returnValue = stock[category].Remove(product);

            if (!returnValue)
            {
                return;
            }

            LowStock(category, oldStockCount);
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

        private void LowStock(string category, int oldStockCount)
        {
            int newStockCount = stock[category].Count;

            threshold.Where(value => oldStockCount > value && newStockCount <= value).ToList().ForEach(i => lowStockNotification(category, $"Less than {i} products left in stock."));
        }
    }
}
