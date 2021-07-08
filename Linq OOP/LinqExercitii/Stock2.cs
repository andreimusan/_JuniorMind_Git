using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercitii
{
    public class Stock2
    {
        private readonly List<List<object>> stock;
        private readonly int firstThreshold = 10;
        private readonly int secondThreshold = 5;
        private readonly int thirdThreshold = 2;
        private readonly Action<object, string, int> lowStockNotification;

        public Stock2(Action<object, string, int> lowStockNotification)
        {
            this.stock = new List<List<object>>();
            this.lowStockNotification = lowStockNotification;
        }

        public void AddProduct(object product)
        {
            int index = GetProductIndex(product);

            if (index < stock.Count)
            {
                stock[index].Add(product);
            }
            else
            {
                stock.Add(new List<object>());
                stock[^1].Add(product);
            }
        }

        public void RemoveProduct(object product)
            {
            int index = GetProductIndex(product);

            if (index >= stock.Count)
            {
                return;
            }

            bool removed = stock[index].Remove(product);

            if (!removed)
            {
                return;
            }

            LowStock(product);
        }

        public int GetProductCount(object product)
        {
            int index = GetProductIndex(product);

            if (index < stock.Count)
            {
                return stock[index].Count;
            }

            return 0;
        }

        public int GetStockCount()
        {
            return stock.Count;
        }

        private int GetProductIndex(object product)
        {
            for (int i = 0; i < stock.Count; i++)
            {
                if (stock[i][0] == product)
                {
                    return i;
                }
            }

            return stock.Count;
        }

        private void LowStock(object product)
        {
            int productCount = GetProductCount(product);

            if (productCount <= thirdThreshold)
            {
                lowStockNotification(product, "message", thirdThreshold);
            }
            else if (productCount <= secondThreshold)
            {
                lowStockNotification(product, "message", secondThreshold);
            }
            else if (productCount <= firstThreshold)
            {
                lowStockNotification(product, "message", firstThreshold);
            }
        }
    }
}
