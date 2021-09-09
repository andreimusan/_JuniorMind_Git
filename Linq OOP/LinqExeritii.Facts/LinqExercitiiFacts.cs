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
            var iPhone8 = new Product { Name = "iPhone 8", ProductCode = "12", Cost = 400 };

            Product emptyProduct = new Product { };
            string emptyMessage = "Product in stock";

            var newStock = new Stock((Product product, string message) => {
                emptyProduct = product;
                emptyMessage = message;
            });

            newStock.AddProduct("phone", iPhone12);
            newStock.AddProduct("phone", samsungS21);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);

            newStock.RemoveProduct("phone", iPhone8);

            Assert.Equal(4, newStock.GetCategoryCount("phone"));
            Assert.Equal("iPhone 8", emptyProduct.Name);
            Assert.Equal("12", emptyProduct.ProductCode);
            Assert.Equal("Less than 2 products left in stock.", emptyMessage);
        }

        [Fact]
        public void TestStockRemoveMultipleValues()
        {
            var iPhone12 = new Product { Name = "iPhone 12", ProductCode = "01", Cost = 1000 };
            var samsungS21 = new Product { Name = "Samsung S21", ProductCode = "02", Cost = 1000 };
            var iPhone8 = new Product { Name = "iPhone 8", ProductCode = "12", Cost = 400 };

            Product emptyProduct = new Product { };
            string emptyMessage = "Product in stock";

            var newStock = new Stock((Product product, string message) => {
                emptyProduct = product;
                emptyMessage = message;
            });

            newStock.AddProduct("phone", iPhone12);
            newStock.AddProduct("phone", samsungS21);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);

            newStock.RemoveProduct("phone", iPhone8, 7);

            Assert.Equal(6, newStock.GetCategoryCount("phone"));
            Assert.Equal("iPhone 8", emptyProduct.Name);
            Assert.Equal("12", emptyProduct.ProductCode);
            Assert.Equal("Less than 5 products left in stock.", emptyMessage);
        }

        [Fact]
        public void TestStockRemoveMultipleValuesWithoutNotification()
        {
            var iPhone12 = new Product { Name = "iPhone 12", ProductCode = "01", Cost = 1000 };
            var samsungS21 = new Product { Name = "Samsung S21", ProductCode = "02", Cost = 1000 };
            var iPhone8 = new Product { Name = "iPhone 8", ProductCode = "12", Cost = 400 };

            Product emptyProduct = new Product { };
            string emptyMessage = "Product in stock";

            var newStock = new Stock((Product product, string message) => {
                emptyProduct = product;
                emptyMessage = message;
            });

            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);
            newStock.AddProduct("phone", iPhone8);

            newStock.RemoveProduct("phone", iPhone8, 3);

            Assert.Equal(12, newStock.GetCategoryCount("phone"));
            Assert.Null(emptyProduct.Name);
            Assert.Null(emptyProduct.ProductCode);
            Assert.Equal("Product in stock", emptyMessage);
        }

        [Fact]
        public void TestStock2()
        {
            var iPhone12 = "iPhone 12";
            object emptyProduct = "Samsung Galaxy S10";
            string emptyMessage = "Product in stock";

            var newStock = new Stock2((object product, string message) => {
                emptyProduct = product;
                emptyMessage = message;
            }, iPhone12);

            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();
            newStock.AddProduct();

            newStock.RemoveProduct();

            Assert.Equal(10, newStock.GetStockCount());
            Assert.Equal(iPhone12, emptyProduct);
            Assert.Equal("Less than 10 products left in stock.", emptyMessage);
        }
    }
}
