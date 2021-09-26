using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercitii
{
    public class Stock
    {
        private readonly Dictionary<string, List<ProductInStock>> stock;
        private readonly Action<ProductInStock, string> lowStockNotification;
        private readonly int[] threshold = { 2, 5, 10 };

        public Stock(Action<ProductInStock, string> lowStockNotification)
        {
            this.stock = new Dictionary<string, List<ProductInStock>>();
            this.lowStockNotification = lowStockNotification;
        }

        public void AddProduct(string category, ProductInStock product)
        {
            if (product == null)
            {
                return;
            }

            if (stock.ContainsKey(category))
            {
                stock[category].Add(product);
            }
            else
            {
                stock.Add(category, new List<ProductInStock> { product });
            }

            product.Count++;
        }

        public void RemoveProduct(string category, ProductInStock product, int quantity = 1)
        {
            if (!stock.ContainsKey(category) || product == null)
            {
                return;
            }

            int oldStockCount = product.Count;
            bool returnValue = false;

            for (int i = 0; i < quantity; i++)
            {
                returnValue = stock[category].Remove(product);
                product.Count--;
            }

            if (!returnValue)
            {
                return;
            }

            LowStock(product, oldStockCount);
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

        private void LowStock(ProductInStock product, int oldStockCount)
        {
            int newStockCount = product.Count;

            int passedThreshold = threshold.FirstOrDefault(value => oldStockCount > value && newStockCount <= value);

            if (passedThreshold > 0)
            {
                lowStockNotification(product, $"Less than {passedThreshold} products left in stock.");
            }
        }
    }
}
