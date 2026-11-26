using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IRecipeRepository
    {
        Task<Recipe?> GetByIdAsync(int id);
        Task<IEnumerable<Recipe>> GetAllAsync();
    }
}
