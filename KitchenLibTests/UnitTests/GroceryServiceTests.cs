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
        public async Task ProcessScan_DecreasesQuantity()
        {
            //Arrange
            string barcode = "123456789";
            int id = 1;
            Grocery? grocery = await _groceryService.GetByIdAsync(id);

            int countBeforeScan = grocery!.Quantity;

            // Act
            await _groceryService.ProcessScanAsync(barcode, ScanMode.Subtract);

            //Assert
            Grocery? updatedGrocery = await _groceryService.GetByIdAsync(id);
            Assert.AreEqual(countBeforeScan - 1, updatedGrocery!.Quantity);
        }

        [TestMethod]
        public async Task ProcessScanAddMode_NewProduct_AddsNewProductWithQuantity1()
        {
            // Arrange
            string newBarcode = "987654321";

            // Act
            int groceryId = (await _groceryService.ProcessScanAsync(newBarcode, ScanMode.Add)).Id;

            // Assert
            Grocery? addedGrocery = await _groceryService.GetByIdAsync(groceryId);
            Assert.AreEqual(1, addedGrocery.Quantity);
        }

        [TestMethod]
        public async Task ProcessScanSubtractMode_NewProduct_ThrowsNullReferenceException()
        {
            // Arrange
            string nonexistentBarcode = "0000";

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await _groceryService.ProcessScanAsync(nonexistentBarcode, ScanMode.Subtract));

        }

        [TestMethod]
        public async Task ProcessScan_BadBarcode_ThrowsNullReferenceException()
        {
            // Arrange
            string nonexistentBarcode = "0000";

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(async () => await _groceryService.ProcessScanAsync(nonexistentBarcode, ScanMode.Add));
        }

        [TestMethod]
        public async Task AddAsync_ValidIngredient_AddsGrocery()
        {
            // Arrange
            var repository = new FakeGroceryRepository();
            var productProvider = new FakeProductInfoProvider();
            var classifierMock = new Mock<IIngredientClassifier>();

            classifierMock
                .Setup(c => c.ClassifyAsync(It.IsAny<ProductInfo>()))
                .ReturnsAsync(new Ingredient { Id = 1, Name = "Milk" });

            var groceryService = new GroceryService(repository, productProvider, classifierMock.Object);

            // Act
            Grocery? grocery = await groceryService.AddAsync("Whole Milk 1l", "Milk", 2);

            // Assert
            Assert.IsNotNull(grocery);
            Assert.AreEqual("Whole Milk 1l", grocery.Name);
            Assert.AreEqual(2, grocery.Quantity);
            Assert.AreEqual("Milk", grocery.Ingredient);
            Assert.IsTrue(grocery.Id > 0);
        }

        [TestMethod]
        public async Task AddAsync_UnknownIngredient_ThrowsArgumentException()
        {
            // Arrange
            var repository = new FakeGroceryRepository();
            var productProvider = new FakeProductInfoProvider();
            var classifierMock = new Mock<IIngredientClassifier>();

            classifierMock
                .Setup(c => c.ClassifyAsync(It.IsAny<ProductInfo>()))
                .ReturnsAsync((Ingredient?)null);

            var groceryService = new GroceryService(repository, productProvider, classifierMock.Object);

            // Act + Assert
            await Assert.ThrowsExactlyAsync<ArgumentException>(
                () => groceryService.AddAsync("Unknown Item", "NotAnIngredient", 1));
        }

    }
}
