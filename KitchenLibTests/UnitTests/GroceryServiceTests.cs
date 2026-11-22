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
            string barcode = "123456789";

            Grocery grocery = await _groceryService.GetByBarcodeAsync(barcode);
            int countBeforeScan = grocery.Quantity;

            // Act
            ScanRequest request = new ScanRequest
            {
                Barcode = barcode,
                Mode = ScanMode.Add
            };
            await _groceryService.ProcessScanAsync(request);

            // Assert
            Grocery updatedGrocery = await _groceryService.GetByBarcodeAsync(barcode);
            int countAfterScan = updatedGrocery.Quantity;
            Assert.AreEqual(countBeforeScan + 1, countAfterScan);
        }
    }
}
