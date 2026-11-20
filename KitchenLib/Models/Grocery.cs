namespace KitchenLib.Models
{
    public class Grocery
    {
        #region Instance fields
        private int _id;
        private string? _barcode;
		private string _name;
		private string? _ingredientType;
		private string? _category;
        private int _quantity;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string? Barcode
		{
			get { return _barcode; }
			set { _barcode = value; }
		}
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string? IngredientType
        {
            get { return _ingredientType; }
            set { _ingredientType = value; }
        }
        public string? Category
        {
            get { return _category; }
            set { _category = value; }
        }
        #endregion

        #region Constructors
        public Grocery()
        {
            _id = 0;
            _barcode = "";
            _name = "";
            _ingredientType = null;
            _category = null;
        }
        public Grocery(int id, string? barcode, string name, string? ingredientType, string? category)
        {
            _id = id;
            _barcode = barcode;
            _name = name;
            _ingredientType = ingredientType;
            _category = category;
        }
        #endregion

    }
}
