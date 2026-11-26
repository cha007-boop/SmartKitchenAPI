using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.Fakes
{
    public class FakeIngredientCatalog : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>
        {
            new() { Id = 1, Name = "Milk" },
            new() { Id = 2, Name = "Chicken" },
            new() { Id = 3, Name = "Tomato" },
            new() { Id = 4, Name = "Olive Oil" }
        };

        public Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Ingredient>>(_ingredients);
        }

        public Task<Ingredient?> GetByIdAsync(int id)
        {
            return Task.FromResult(_ingredients.FirstOrDefault(i => i.Id == id));
        }
    }
}
