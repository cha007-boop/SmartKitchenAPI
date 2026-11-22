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
        public string Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public List<string> IngredientStrings { get; set; }
        public List<string> Measure { get; set; }
        public string? Instructions { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? Tags { get; set; }
        #endregion

        #region Constructors
        public Recipe()
        {
            Id = 0;
            Name = "";
            Description = "";
            ThumbnailUrl = null;
            IngredientStrings = new List<string>();
            Measure = new List<string>();
            Instructions = null;
            YoutubeUrl = null;
            Tags = null;
        }
        public Recipe(int id, string name, string description, string? thumbnailUrl, List<string> ingredientStrings, List<string> measure, string? instructions, string? youtubeUrl, string? tags)
        {
            Id = id;
            Name = name;
            Description = description;
            ThumbnailUrl = thumbnailUrl;
            IngredientStrings = ingredientStrings;
            Measure = measure;
            Instructions = instructions;
            YoutubeUrl = youtubeUrl;
            Tags = tags;
        }
        #endregion
    }
}
