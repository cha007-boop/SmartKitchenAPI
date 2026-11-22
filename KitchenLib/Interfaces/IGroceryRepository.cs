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
        Task<IEnumerable<Grocery>> GetAllAsync(int? id = null, string? barcode = null, string? name = null, string? ingredientType = null, string? category = null);
        Grocery? Update(int id, Grocery grocery);
        Grocery? Delete(int id);

    }
}
