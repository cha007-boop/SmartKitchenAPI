using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib
{
    public class Ingredient
    {
        #region Instance fields
        private int _id;
		private string _name;
		private string _description;
        private string? _thumbnailUrl;
        private string? _type;
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
        public string? Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        #region Constructors
        public Ingredient()
        {
            _id = 0;
            _name = "";
            _description = "";
            _thumbnailUrl = null;
            _type = null;
        }
        public Ingredient(int id, string name, string description, string thumbnaiUrl, string type)
        {
            _id = id;
            _name = name;
            _description = description;
            _thumbnailUrl = thumbnaiUrl;
            _type = type;
        }
        #endregion

    }
}
