using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercitii
{
    public class Stock2
    {
        private readonly List<object> stock;
        private readonly object product;
        private readonly int firstThreshold = 10;
        private readonly int secondThreshold = 5;
        private readonly int thirdThreshold = 2;
        private readonly Action<object, object, string, string> lowStockNotification;

        public Stock2(Action<object, object, string, string> lowStockNotification, object product)
        {
            this.stock = new List<object>();
            this.lowStockNotification = lowStockNotification;
            this.product = product;
            this.NotificationMessage = $"{GetStockCount()} products left in stock.";
            this.NotificationObject = product;
        }

        public object NotificationObject { get; set; }

        public string NotificationMessage { get; set; }

        public void AddProduct()
        {
            stock.Add(product);
        }

        public void RemoveProduct()
        {
            bool removed = stock.Remove(product);

            if (!removed)
            {
                return;
            }

            LowStock();
        }

        public int GetStockCount()
        {
            return stock.Count;
        }

        private void LowStock()
        {
            int productCount = GetStockCount();

            if (productCount <= thirdThreshold)
            {
                lowStockNotification(product, NotificationObject, NotificationMessage, $"{GetStockCount()} products left in stock.");
            }
            else if (productCount <= secondThreshold)
            {
                lowStockNotification(product, NotificationObject, NotificationMessage, $"{GetStockCount()} products left in stock.");
            }
            else if (productCount <= firstThreshold)
            {
                lowStockNotification(product, NotificationObject, NotificationMessage, $"{GetStockCount()} products left in stock.");
            }
        }
    }
}
