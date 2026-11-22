using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Repositories
{
    public class GroceryRepositoryDB : IGroceryRepository
    {

        private string _connectionString;

        public GroceryRepositoryDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Grocery Add(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public List<Grocery> GetAll(int? id = null, string? barcode = null, string? name = null, string? ingredientType = null, string? category = null, int? minQuantity = null, int? maxQuantity = null)
        {
            throw new NotImplementedException();
        }

        public Grocery? GetByBarcode(string barcode)
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
        public Grocery? Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
