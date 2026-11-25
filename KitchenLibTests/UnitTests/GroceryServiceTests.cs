using KitchenLib.Interfaces;
using KitchenLib.Models;
using KitchenLib.Services;
using KitchenLibTests.Fakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.UnitTests
{
    [TestClass]
    public class GroceryServiceTests
    {
        private IGroceryService _groceryService;

        [TestInitialize]
        public void TestInitialize()
        {
            var repository = new FakeGroceryRepository();
            var productProvider = new FakeProductInfoProvider();
            var classifier = new FakeIngredientClassifier();

            _groceryService = new GroceryService(
                repository,
                productProvider,
                classifier
            );
        }

        [TestMethod]
        public async Task ProcessScanAsync_IncreasesQuantity_ExistingGroceryAddMode()
        {
            // Arrange
            int id = 1;

            Grocery grocery = await _groceryService.GetByIdAsync(id);
            int countBeforeScan = grocery.Quantity;

            // Act
            await _groceryService.ProcessScanAsync(grocery.Barcode, ScanMode.Add);

            // Assert
            Grocery updatedGrocery = await _groceryService.GetByIdAsync(id);
            int countAfterScan = updatedGrocery.Quantity;
            Assert.AreEqual(countBeforeScan + 1, countAfterScan);
        }

        [TestMethod]
        public async Task GetByIdAsync_Returns_CorrectGrocery()
        {
            //Arrange
            Grocery grocery = new Grocery
            {
                Barcode = "SomeBarcode",
                Name = "Name",
                Quantity = 1,
                Ingredient = "SomeIngredient",
                Category = "Category"
            };
            Grocery thisGrocery = await _groceryService.AddGroceryAsync(grocery.Barcode);

            int id = thisGrocery.Id;
            //Act 
            Grocery? actualGrocery = await _groceryService.GetByIdAsync(id);

            //Assert
            Assert.AreEqual(actualGrocery.Barcode, grocery.Barcode);
            Assert.AreEqual(actualGrocery.Name, grocery.Name);
            Assert.AreEqual(actualGrocery.Quantity, grocery.Quantity);
            Assert.AreEqual(actualGrocery.Ingredient, grocery.Ingredient);
            Assert.AreEqual(actualGrocery.Category, grocery.Category);
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
