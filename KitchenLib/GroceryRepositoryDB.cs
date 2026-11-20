using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib
{
    public class GroceryRepositoryDB : IGroceryRepository
    {
        private readonly string _productionDBconnectionString = "";
        private readonly string _testDBconnectionString = "";

        private string _connectionString;

        public GroceryRepositoryDB(bool test = false)
        {
            if (test)
            {
                _connectionString = _testDBconnectionString;
            }
            else
            {
                _connectionString = _productionDBconnectionString;
            }
        }

        public Grocery Add(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public List<Grocery> GetAll(int? id = null, string? barcode = null, string? name = null, string? ingredientType = null, string? category = null)
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
