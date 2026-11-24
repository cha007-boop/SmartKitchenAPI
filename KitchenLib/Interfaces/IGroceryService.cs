using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IGroceryService
    {
        Task ProcessScanAsync(string barcode, ScanMode mode);
        Task<Grocery?> GetByIdAsync(int id);
        Task<IEnumerable<Grocery>> GetAllAsync();
        Task AddGroceryAsync(string barcode);
        Task UseGroceryAsync(string barcode);
    }
}
