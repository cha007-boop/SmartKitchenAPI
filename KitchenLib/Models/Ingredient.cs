using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Models
{
    public class Ingredient
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Type { get; set; }
        #endregion

        #region Constructors
        public Ingredient()
        {
            Id = 0;
            Name = "";
            Description = "";
            ThumbnailUrl = null;
            Type = null;
        }
        public Ingredient(int id, string name, string description, string thumbnaiUrl, string type)
        {
            Id = id;
            Name = name;
            Description = description;
            ThumbnailUrl = thumbnaiUrl;
            Type = type;
        }
        #endregion

    }
}
