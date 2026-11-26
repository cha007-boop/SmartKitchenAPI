using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IGroceryService
    {
        Task<Grocery?> ProcessScanAsync(string barcode, ScanMode mode);
        Task<Grocery?> GetByIdAsync(int id);
        Task<IEnumerable<Grocery>> GetAllAsync();
        Task<Grocery?> DeleteAsync(int id);
        Task<Grocery?> AddQuantity(int id);
    }
}
