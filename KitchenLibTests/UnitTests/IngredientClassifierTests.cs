using KitchenLib.Models;
using KitchenLib.Repositories;
using KitchenLib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.UnitTests
{
    [TestClass]
    public class IngredientClassifierTests
    {
        private IngredientClassifier _classifier;

        [TestInitialize]
        public void TestInitialize()
        {

            _classifier = new IngredientClassifier();
        }

        [TestMethod]
        [DataRow("Whole Milk ", "en:Milk", "Milk")]
        [DataRow("6 piece chicken breast", "en:chicken","Chicken")]
        [DataRow("Fresh Tomatos 100g", "tomato", "Tomato")]

        public async Task ClassifyAsync_MatchesByCategoryString(string productName, string productCategories, string ingredientName)
        {
            // Arrange
            var product = new ProductInfo
            {
                Name = productName,
                Categories = productCategories
            };

            // Act
            Ingredient? result =
                await _classifier.ClassifyAsync(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ingredientName, result.Name);
        }



    }
}
