using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using KitchenLib.Interfaces;
using KitchenLib.Models;
using KitchenLib.Repositories;

namespace KitchenLib.Services
{
    public class IngredientClassifier : IIngredientClassifier
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientClassifier(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<Ingredient> ClassifyAsync(ProductInfo productInfo)
        {
            IEnumerable<Ingredient> ingredients = await _ingredientRepository.GetAllAsync();

            List<String> productTags = productInfo.Categories.Split(',').ToList();
            for(int i = productTags.Count; i > 0; i--)
            {
                foreach(Ingredient element in ingredients)
                {
                    if (productTags[i].Length == element.Name.Length + 1)
                    {
                        char[] chars = element.Name.ToCharArray();
                        String singleelementname = "";
                        for (int n = 0;  n < chars.Length - 1; n++)
                        {
                            singleelementname = $"{singleelementname}{chars[n]}";
                        }
                        if (singleelementname.Equals(productTags[i]))
                        {
                            return element;
                        }
                    }
                }
            }
            return null;
        }
    }
}
