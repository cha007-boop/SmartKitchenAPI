using System;
using System.Collections.Generic;
using System.Text;
using KitchenLib.Interfaces;
using KitchenLib.Models;

namespace KitchenLib.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        public Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
