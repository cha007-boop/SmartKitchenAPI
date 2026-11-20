using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Models
{
    public class Recipe
    {
        #region Instance fields
        private int _id;
        private string _name;
        private string _description;
        private string? _thumbnailUrl;
        private List<Grocery> _ingredients;
        private List<string> _measure;
        private string? _instructions;
        private string? _youtubeUrl;
        private string? _tags;
        #endregion
        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string? ThumbnailUrl
        {
            get { return _thumbnailUrl; }
            set { _thumbnailUrl = value; }
        }
        public List<Grocery> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }
        public List<string> Measure
        {
            get { return _measure; }
            set { _measure = value; }
        }
        public string? Instructions
        {
            get { return _instructions; }
            set { _instructions = value; }
        }
        public string? YoutubeUrl
        {
            get { return _youtubeUrl; }
            set { _youtubeUrl = value; }
        }
        public string? Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
        #endregion
    }
}
