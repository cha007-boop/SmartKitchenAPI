using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IGroceryService
    {
        Task ProcessScanAsync(ScanRequest request);
        Task<Grocery?> GetByIdAsync(int id);
        Task<IEnumerable<Grocery>> GetAllAsync();
    }
}
