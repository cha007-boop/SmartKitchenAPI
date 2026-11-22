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

        public Task<Grocery?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grocery>> GetAllAsync()
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

        public Task<Grocery?> UpdateAsync(int id, Grocery grocery)
        {
            throw new NotImplementedException();
        }
    }
}
