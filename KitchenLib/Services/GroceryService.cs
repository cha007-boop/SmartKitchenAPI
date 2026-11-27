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
                    Ingredient? ingredient = null;
                    try
                    {
                        ingredient = await _ingredientClassifier.ClassifyAsync(productInfo);
                    }
                    catch (ArgumentException)
                    {
                        ingredient = null;
                    }



                    grocery = new Grocery
                    {
                        Barcode = barcode,
                        Name = productInfo.Name,
                        Quantity = 1,
                        Ingredient = ingredient?.Name,
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
        public async Task<Grocery> ManuelAddAsync(string name, string ingredient, int quantity)
        {
            ProductInfo productInfo = new ProductInfo { Barcode = "", Brand = "", Categories = ingredient, Name = name };

            Ingredient ingredientResult = new Ingredient();
            try
            {
                ingredientResult = await _ingredientClassifier.ClassifyAsync(productInfo);
            }
            catch (ArgumentException)
            {
                ingredientResult = new Ingredient { Id = 0, Name = ingredient };
            }

            return await _groceryRepository.AddAsync(new Grocery { Ingredient = ingredientResult.Name, Name = name, Quantity = quantity });
        }

        public async Task<Grocery?> UpdateAsync(int id, Grocery updatedGrocery)
        {
            Grocery? existingGrocery = await _groceryRepository.GetByIdAsync(id);
            if (existingGrocery == null)
            {
                return null;
            }
            string? ingredient = "";
            try
            {
                ProductInfo productInfo = new ProductInfo
                {
                    Name = updatedGrocery.Name,
                    Categories = updatedGrocery.Ingredient
                };
                ingredient = (await _ingredientClassifier.ClassifyAsync(productInfo)).Name;
            }
            catch (ArgumentException)
            {
                ingredient = updatedGrocery.Ingredient;
            }



            existingGrocery.Name = updatedGrocery.Name;
            existingGrocery.Barcode = updatedGrocery.Barcode ?? existingGrocery.Barcode;
            existingGrocery.Quantity = updatedGrocery.Quantity;
            existingGrocery.Ingredient = ingredient;
            existingGrocery.Category = updatedGrocery.Category ?? existingGrocery.Category;
            return await _groceryRepository.UpdateAsync(id, existingGrocery);
        }

    }
}
