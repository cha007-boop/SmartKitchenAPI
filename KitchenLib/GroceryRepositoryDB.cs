using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib
{
    public class GroceryRepositoryDB : IGroceryRepository
    {
        public Grocery Add(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public Grocery? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Grocery> GetAll(int? id = null, int? barcode = null, string? name = null, string? ingredientType = null, string? category = null)
        {
            throw new NotImplementedException();
        }

        public Grocery? GetByBarcode(int barcode)
        {
            throw new NotImplementedException();
        }

        public Grocery? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Grocery? Update(int id, Grocery grocery)
        {
            throw new NotImplementedException();
        }
    }
}
