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

        public Task<Grocery> AddAsync(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public Grocery? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grocery>> GetAllAsync(int? id = null, string? barcode = null, string? name = null, string? ingredient = null, string? category = null, int? minQuantity = null, int? maxQuantity = null)
        {
            throw new NotImplementedException();
        }

        public Task<Grocery?> GetByBarcodeAsync(string barcode)
        {
            throw new NotImplementedException();
        }

        public Task<Grocery?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Grocery? Update(int id, Grocery grocery)
        {
            throw new NotImplementedException();
        }
    }
}
