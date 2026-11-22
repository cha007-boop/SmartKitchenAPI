using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Services
{
    public class IngredientClassifier : IIngredientClassifier
    {
        public Task<IEnumerable<Ingredient>> ClassifyAsync(ProductInfo productInfo)
        {
            throw new NotImplementedException();
        }
    }
}
