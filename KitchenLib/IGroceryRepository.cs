using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib
{
    public interface IGroceryRepository
    {
        Grocery Add(Grocery grocery);
        Grocery? GetById(int id);
        Grocery? GetByBarcode(string barcode);
        List<Grocery> GetAll(int? id = null, string? barcode = null, string? name = null, string? ingredientType = null, string? category = null);
        Grocery? Update(int id, Grocery grocery);
        Grocery? Delete(int id);

    }
}
