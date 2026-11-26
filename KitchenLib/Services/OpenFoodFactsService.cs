using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Services
{
    public class OpenFoodFactsService : IProductInfoProvider
    {
        private readonly HttpClient _httpClient;

        public OpenFoodFactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ProductInfo?> GetByBarcodeAsync(string barcode)
        {
            var productinfo = new ProductInfo
            {
                Barcode = barcode,
                Name = "Test Product",
                Brand = "Test Brand",
                Categories = "Milk, Dairy"
            };
            return Task.FromResult<ProductInfo?>(productinfo);
        }
    }
}
