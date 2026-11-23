using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Models
{
    public class Recipe
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string? AlternateName { get; set; }
        public string? Category { get; set; }
        public string? Area { get; set; }
        public string? Country { get; set;}
        public List<string> IngredientStrings { get; set; }
        public List<string> Measures { get; set; }
        public string? Instructions { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Tags { get; set; }
        public string? YoutubeUrl { get; set; }

        #endregion

        #region Constructors
        public Recipe()
        {
            Id = 0;
            Name = "";
            Category = "";
            Area = "";
            Country = "";
            ThumbnailUrl = null;
            IngredientStrings = new List<string>();
            Measures = new List<string>();
            Instructions = null;
            YoutubeUrl = null;
            Tags = null;
        }
        public Recipe(int id, string name, string? category, string? area, string? country, string? thumbnailUrl, List<string> ingredientStrings, List<string> measure, string? instructions, string? youtubeUrl, string? tags)
        {
            Id = id;
            Name = name;
            Category = category;
            Area = area;
            Country = country;
            ThumbnailUrl = thumbnailUrl;
            IngredientStrings = ingredientStrings;
            Measures = measure;
            Instructions = instructions;
            YoutubeUrl = youtubeUrl;
            Tags = tags;
        }
        #endregion
    }
}
