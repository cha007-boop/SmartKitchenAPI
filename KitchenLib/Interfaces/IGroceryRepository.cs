using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IGroceryRepository
    {
        Task<Grocery> AddAsync(Grocery grocery);
        Task<Grocery?> GetByIdAsync(int id);
        Task<Grocery?> GetByBarcodeAsync(string barcode);
        Task<IEnumerable<Grocery>> GetAllAsync();

        // Maybe just do filtering and sorting in front-end?
        //Task<IEnumerable<Grocery>> GetAllAsync(int? id = null, string? barcode = null, string? name = null, string? ingredient = null, string? category = null, int? minQuantity = null, int? maxQuantity = null);
        Task<Grocery?> UpdateAsync(int id, Grocery grocery);
        Task<Grocery?> DeleteAsync(int id);
        Task<Grocery?> AddQuantityAsync(int id);

    }
}
