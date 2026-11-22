using KitchenLib.Interfaces;
using KitchenLib.Models;
using KitchenLib.Services;
using KitchenLibTests.Fakes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace KitchenLibTests.UnitTests
{
    [TestClass]
    public sealed class OpenFoodFactsTests
    {
        //[TestInitialize]
        //public void TestInitialize()
        //{


        //}

        [TestMethod]
        public async Task GetByBarcodeAsync_ReturnsProduct_WhenProductExists()
        {
            // Arrange
            string json = """
                {
                    "status": 1,
                    "product": {
                        "product_name": "Whole Milk",
                        "brands": "Example Brand",
                        "categories": "Dairy products"
                    }
                }
                """;

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                )
            };

            var handler = new FakeHttpMessageHandler(response);
            var httpClient = new HttpClient(handler);

            var openFoodFactsService = new OpenFoodFactsService(httpClient);

            var barcode = "123456789";

            // Act
            ProductInfo? result = await openFoodFactsService.GetByBarcodeAsync(barcode);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Whole Milk", result.Name);
            Assert.AreEqual("Example Brand", result.Brand);
            Assert.AreEqual("Dairy products", result.Categories);
            Assert.AreEqual(barcode, result.Barcode);
        }

    }
}
