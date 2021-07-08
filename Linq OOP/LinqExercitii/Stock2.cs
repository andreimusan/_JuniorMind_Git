using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercitii
{
    public class Stock2
    {
        private readonly List<object> stock;
        private readonly int firstThreshold = 10;
        private readonly int secondThreshold = 5;
        private readonly int thirdThreshold = 2;
        private readonly Action<object, string, int> lowStockNotification;

        public Stock2(Action<object, string, int> lowStockNotification)
        {
            this.stock = new List<object>();
            this.lowStockNotification = lowStockNotification;
        }

        public void AddProduct(object product)
        {
            stock.Add(product);
        }

        public void RemoveProduct(object product)
        {
            bool removed = stock.Remove(product);

            if (!removed)
            {
                return;
            }

            LowStock(product);
        }

        public int GetStockCount()
        {
            return stock.Count;
        }

        private void LowStock(object product)
        {
            int productCount = GetStockCount();

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
