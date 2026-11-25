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

        public async Task<Grocery?> ProcessScanAsync(string barcode, ScanMode mode)
        {
            Grocery? grocery = await _groceryRepository.GetByBarcodeAsync(barcode);
            if (mode == ScanMode.Add)
            {
                if (grocery != null)
                {
                    grocery.Quantity += 1;
                    await _groceryRepository.UpdateAsync(grocery.Id, grocery);
                }
                else
                {
                    ProductInfo productInfo = await _productInfoProvider.GetByBarcodeAsync(barcode) ?? throw new NullReferenceException();
                    IEnumerable<Ingredient> possibleIngredients = await _ingredientClassifier.ClassifyAsync(productInfo);

                    grocery = new Grocery
                    {
                        Barcode = barcode,
                        Name = productInfo.Name,
                        Quantity = 1,
                        Ingredient = possibleIngredients.FirstOrDefault()?.Name,
                        Category = productInfo.Categories
                    };

                    await _groceryRepository.AddAsync(grocery);
                }
            }
            else if (mode == ScanMode.Subtract)
            {
                if (grocery != null && grocery.Quantity > 0)
                {
                    grocery.Quantity -= 1;
                    await _groceryRepository.UpdateAsync(grocery.Id, grocery);
                }
                else { throw new NullReferenceException(); }
            }
            return grocery;
        }
        public Task<Grocery?> GetByIdAsync(int id)
        {
            return _groceryRepository.GetByIdAsync(id);
        }
        public Task<IEnumerable<Grocery>> GetAllAsync()
        {
            return _groceryRepository.GetAllAsync();
        }
    }
}
