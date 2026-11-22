using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.Fakes
{

    public class FakeGroceryRepository : IGroceryRepository
    {
        private readonly List<Grocery> _groceries = new();
        private int _nextId = 1;

        public Task<Grocery> AddAsync(Grocery grocery)
        {
            grocery.Id = _nextId++;
            _groceries.Add(grocery);

            return Task.FromResult(grocery);
        }

        public Task<Grocery?> GetByIdAsync(int id)
        {
            var grocery = _groceries.FirstOrDefault(g => g.Id == id);

            return Task.FromResult(grocery);
        }

        public Task<Grocery?> GetByBarcodeAsync(string barcode)
        {
            var grocery = _groceries.FirstOrDefault(g => g.Barcode == barcode);

            return Task.FromResult(grocery);
        }

        public Task<IEnumerable<Grocery>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Grocery>>(_groceries.ToList());
        }

        public Task<Grocery?> UpdateAsync(int id, Grocery grocery)
        {
            var existing = _groceries.FirstOrDefault(g => g.Id == id);

            if (existing == null)
            {
                return Task.FromResult(existing);
            }

            existing.Name = grocery.Name;
            existing.Barcode = grocery.Barcode;
            existing.Quantity = grocery.Quantity;
            existing.Ingredient = grocery.Ingredient;

            return Task.FromResult(existing)!;
        }

        public Task<Grocery?> DeleteAsync(int id)
        {
            var grocery = _groceries.FirstOrDefault(g => g.Id == id);

            if (grocery == null)
            {
                return Task.FromResult(grocery);
            }

            _groceries.Remove(grocery);

            return Task.FromResult(grocery)!;
        }
    }

}
