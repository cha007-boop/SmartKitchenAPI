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
    public sealed class ProductInfoTests
    {
        private IProductInfoProvider _productInfoProvider;
        [TestInitialize]
        public void TestInitialize()
        {


        }

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

            // Act
            ProductInfo? result = await openFoodFactsService.GetByBarcodeAsync("123456789");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Whole Milk", result.Name);
            Assert.AreEqual("Example Brand", result.Brand);
        }

    }
}
