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
        private readonly Action<int> lowStockNotification;

        public Stock(Action<int> lowStockNotification)
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

            bool returnValue = stock[category].Remove(product);

            if (!returnValue)
            {
                return;
            }

            LowStock(category);
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

        private void LowStock(string category)
        {
            int stockCount = stock[category].Count;

            if (stockCount <= thirdThreshold)
            {
                lowStockNotification(thirdThreshold);
            }
            else if (stockCount <= secondThreshold)
            {
                lowStockNotification(secondThreshold);
            }
            else if (stockCount <= firstThreshold)
            {
                lowStockNotification(firstThreshold);
            }
        }
    }
}
