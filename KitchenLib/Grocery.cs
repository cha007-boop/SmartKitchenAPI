namespace KitchenLib
{
    public class Grocery
    {
        #region Instance fields
        private int _id;
        private int? _barcode;
		private string _name;
		private Ingredient? _ingredientType;
		private string? _category;
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int? Barcode
		{
			get { return _barcode; }
			set { _barcode = value; }
		}
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Ingredient? IngredientType
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
            _barcode = null;
            _name = "";
            _ingredientType = null;
            _category = null;
        }
        public Grocery(int id, int? barcode, string name, Ingredient? ingredientType, string? category)
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
