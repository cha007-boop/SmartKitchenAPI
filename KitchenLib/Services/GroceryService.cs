using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Services
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;
        private readonly IProductInfoProvider _productInfoProvider;
        private readonly IIngredientClassifier _ingredientClassifier;

        public GroceryService(
            IGroceryRepository groceryRepository,
            IProductInfoProvider productInfoProvider,
            IIngredientClassifier ingredientClassifier)
        {
            _groceryRepository = groceryRepository;
            _productInfoProvider = productInfoProvider;
            _ingredientClassifier = ingredientClassifier;
        }

        public Task<IEnumerable<Grocery>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
