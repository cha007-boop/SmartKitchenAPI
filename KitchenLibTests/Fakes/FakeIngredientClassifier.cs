using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLibTests.Fakes
{
    public class FakeIngredientClassifier : IIngredientClassifier
    {
        private List<Ingredient> _ingredients = new List<Ingredient>()
        {
            new Ingredient{ Id = 1, Name = "Milk", Description= "It's milk whatever", Type = "Dairy" },
            new Ingredient{ Id = 2, Name = "Apples", Description= "Fresh apples", Type = "Fruit" },
            new Ingredient{ Id = 3, Name = "Basil", Type = "Herbs" },
            new Ingredient{ Id = 4, Name = "Chicken breast", Description= "Chicken breast", Type = "Meat" },
            new Ingredient{ Id = 5, Name = "Rice", Type = "Grains" },
            new Ingredient{ Id = 6, Name = "Tomatoes", Type = "Vegetables" },
            new Ingredient{ Id = 7, Name = "Cheese" },
            new Ingredient{ Id = 8, Name = "Pasta"}
        };

        public Task<IEnumerable<Ingredient>> ClassifyAsync(ProductInfo productInfo)
        {
            List<string> productCategories = productInfo.Categories.Split(",").ToList();
            List<Ingredient> possibleMatches = new List<Ingredient>();

            foreach (var ingredient in _ingredients)
            {
                foreach (var category in productCategories)
                {
                    if (ingredient.Type != null && ingredient.Type.Contains(category, StringComparison.OrdinalIgnoreCase))
                    {
                        possibleMatches.Add(ingredient);
                        break; // No need to check other categories for this ingredient
                    }
                }
            }

            return Task.FromResult<IEnumerable<Ingredient>>(possibleMatches);
        }
    }
}
