using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IGroceryService
    {
        Task ProcessScanAsync(ScanRequest request);
        Task<Grocery?> GetByBarcodeAsync(string barcode);
        Task<IEnumerable<Grocery>> GetAllAsync();
    }
}
