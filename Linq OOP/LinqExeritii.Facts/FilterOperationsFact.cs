using LinqExercitii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LinqExeritii.Facts
{
    public class FilterOperationsFact
    {
        [Fact]
        public void Test_FilterProductWithFeatures()
        {
            var cost = new Feature { Id = 1 };
            var weight = new Feature { Id = 2 };
            var length = new Feature { Id = 3 };
            var height = new Feature { Id = 4 };
            var color = new Feature { Id = 5 };

            var featureList = new List<Feature>
            {
                cost,
                height,
                color
            };

            var phone = new Product
            {
                Name = "phone",
                Features = new List<Feature>
                {
                    cost,
                    weight,
                    height,
                    length,
                    color
                }
            };

            var laptop = new Product
            {
                Name = "laptop",
                Features = new List<Feature>
                {
                    cost,
                    weight
                }
            };

            var tablet = new Product
            {
                Name = "tablet",
                Features = new List<Feature>
                {
                    length,
                    height,
                    color
                }
            };

            var mouse = new Product
            {
                Name = "mouse",
                Features = new List<Feature>
                {
                    weight
                }
            };

            var keyboard = new Product
            {
                Name = "keyboard",
                Features = new List<Feature>
                {
                    length,
                    height
                }
            };

            var productList = new List<Product>
            {
                phone,
                laptop,
                tablet,
                mouse,
                keyboard
            };

            var oneFeature = FilterOperations.FilterProductWithOneFeature(productList, featureList);
            var allFeature = FilterOperations.FilterProductWithAllFeatures(productList, featureList);
            var noneFeature = FilterOperations.FilterProductWithNoFeature(productList, featureList);

            Assert.Equal(new List<Product> { phone, laptop, tablet, keyboard }, oneFeature);
            Assert.Equal(new List<Product> { phone }, allFeature);
            Assert.Equal(new List<Product> { mouse }, noneFeature);
        }

        [Fact]
        public void Test_MergeListsOfProducts()
        {
            var productList1 = new List<ProductStruct>
            {
                new ProductStruct { Name = "phone", Quantity = 5 },
                new ProductStruct { Name = "laptop", Quantity = 10 },
                new ProductStruct { Name = "tablet", Quantity = 5 }
            };

            var productList2 = new List<ProductStruct>
            {
                new ProductStruct { Name = "laptop", Quantity = 5 },
                new ProductStruct { Name = "tablet", Quantity = 20 },
                new ProductStruct { Name = "mouse", Quantity = 10 },
                new ProductStruct { Name = "keyboard", Quantity = 5 }
            };

            var mergedList = FilterOperations.MergeListsOfProducts(productList1, productList2);

            var result = new List<ProductStruct>
            {
                new ProductStruct { Name = "phone", Quantity = 5 },
                new ProductStruct { Name = "laptop", Quantity = 15 },
                new ProductStruct { Name = "tablet", Quantity = 25 },
                new ProductStruct { Name = "mouse", Quantity = 10 },
                new ProductStruct { Name = "keyboard", Quantity = 5 }
            };

            Assert.Equal(result, mergedList);
        }

        [Fact]
        public void Test_MaxScore()
        {
            var familyList = new List<TestResults>
            {
                new TestResults { Id = "1", FamilyId = "Andrei", Score = 10 },
                new TestResults { Id = "2", FamilyId = "Bogdan", Score = 7 },
                new TestResults { Id = "4", FamilyId = "Dan", Score = 5 },
                new TestResults { Id = "1", FamilyId = "Andrei", Score = 3 },
                new TestResults { Id = "4", FamilyId = "Dan", Score = 8 },
                new TestResults { Id = "3", FamilyId = "Dan", Score = 20 },
                new TestResults { Id = "1", FamilyId = "Andrei", Score = 15 },
                new TestResults { Id = "1", FamilyId = "Andrei", Score = 3 }
            };

            var maxScore = FilterOperations.MaxScore(familyList);

            var result = new List<TestResults>
            {
                new TestResults { Id = "1", FamilyId = "Andrei", Score = 15 },
                new TestResults { Id = "2", FamilyId = "Bogdan", Score = 7 },
                new TestResults { Id = "4", FamilyId = "Dan", Score = 8 },
                new TestResults { Id = "3", FamilyId = "Dan", Score = 20 }
            };

            maxScore.SequenceEqual(result);
        }

        [Fact]
        public void Test_MostUsedWords()
        {
            var text = "Ana si ana au mere. Ana si Ana au pere; Ana nu are morcovi";

            var result = new List<string> { "ana", "si", "au" };

            Assert.Equal(result, FilterOperations.MostUsedWords(text, 3));
        }
    }
}
