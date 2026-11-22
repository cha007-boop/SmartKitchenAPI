using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IIngredientRepository
    {
        Task<Ingredient?> GetByIdAsync(int id);
        Task<IEnumerable<Ingredient>> GetAllAsync();
    }
}
