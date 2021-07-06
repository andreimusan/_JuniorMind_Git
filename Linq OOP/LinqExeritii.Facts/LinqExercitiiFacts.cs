using LinqExercitii;
using System;
using System.Collections.Generic;
using Xunit;

namespace LinqExeritii.Facts
{
    public class LinqExercitiiFacts
    {
        [Fact]
        public void TestStock()
        {
            var newStock = new Stock<string, List<Product>>();

            var iPhone12 = new Product { Name = "iPhone 12", ProductCode = "01", Cost = 1000 };
            var samsungS21 = new Product { Name = "Samsung S21", ProductCode = "02", Cost = 1000 };
            var samsungNote10 = new Product { Name = "Samsung Note10", ProductCode = "03", Cost = 700 };
            var nokia3 = new Product { Name = "Nokia 3", ProductCode = "04", Cost = 500 };
            var iPhone11 = new Product { Name = "iPhone 11", ProductCode = "05", Cost = 800 };
            var iPhoneX = new Product { Name = "iPhone X", ProductCode = "06", Cost = 700 };
            var samsungS10 = new Product { Name = "Samsung S10", ProductCode = "07", Cost = 400 };
            var samsungFold2 = new Product { Name = "Samsung Fold2", ProductCode = "08", Cost = 1500 };
            var samsungFlip2 = new Product { Name = "Samsung Flip2", ProductCode = "09", Cost = 1000 };
            var huaweiP20 = new Product { Name = "Huawei P20", ProductCode = "10", Cost = 800 };
            var iPhoneXR = new Product { Name = "iPhone XR", ProductCode = "11", Cost = 400 };
            var iPhone8 = new Product { Name = "iPhone XR", ProductCode = "11", Cost = 400 };

            newStock.AddProduct("phone", iPhone12);
            newStock.AddProduct("phone", samsungS21);
            newStock.AddProduct("phone", samsungNote10);
            newStock.AddProduct("phone", nokia3);
            newStock.AddProduct("phone", iPhone11);
            newStock.AddProduct("phone", iPhoneX);
            newStock.AddProduct("phone", samsungS10);
            newStock.AddProduct("phone", samsungFold2);
            newStock.AddProduct("phone", samsungFlip2);
            newStock.AddProduct("phone", huaweiP20);

            var exception = Assert.Throws<ArgumentException>(() => newStock.RemoveProduct("phone", nokia3, LowStock(newStock, "phone")));
            Assert.Equal("Only 10 products left in phone category.", exception.Message);
        }
        private Action<string> LowStock(Stock<string, List<Product>> stock, string category)
        {
            int firstThreshold = 10;
            int secondThreshold = 5;
            int thirdThreshold = 2;

            int stockCount = stock.GetCategoryCount(category);

            if (stockCount <= thirdThreshold)
            {
                throw new ArgumentException($"Less than {thirdThreshold} products left in {category} category.");
            }
            else if (stockCount <= secondThreshold)
            {
                throw new ArgumentException($"Only {secondThreshold} products left in {category} category.");
            }
            else if (stockCount <= firstThreshold)
            {
                throw new ArgumentException($"Only {firstThreshold} products left in {category} category.");
            }

            return null;
        }
    }
}
