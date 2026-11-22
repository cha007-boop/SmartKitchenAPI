using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IProductInfoProvider
    {
        Task<ProductInfo> GetByBarcodeAsync(string barcode);
    }
}
