using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.Fakes
{
    public class FakeProductInfoProvider : IProductInfoProvider
    {
        private readonly List<ProductInfo> _products = new List<ProductInfo>
        {
            new ProductInfo { Barcode = "123456789", Name = "Milk", Categories = "Dairy products, Milk", Brand = "Example Brand" },
            new ProductInfo { Barcode = "987654321", Name = "6 pieces of Chicken", Categories = "Chicken,Chicken breast,poultry"}
        };

        public Task<ProductInfo?> GetByBarcodeAsync(string barcode)
        {
            ProductInfo? product = _products
                .FirstOrDefault(p => p.Barcode == barcode);

            return Task.FromResult(product);
        }
    }
}
