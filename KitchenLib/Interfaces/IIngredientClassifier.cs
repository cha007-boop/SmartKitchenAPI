using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Interfaces
{
    public interface IIngredientClassifier
    {
        Task<Ingredient> ClassifyAsync(ProductInfo productInfo);
    }
}
