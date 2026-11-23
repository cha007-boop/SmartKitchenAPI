namespace KitchenLib.Models
{
    public class Grocery
    {
        #region Properties
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string? Ingredient { get; set; }
        public string? Category { get; set; }
        #endregion

        #region Constructors
        public Grocery()
        {
            Id = 0;
            Barcode = "";
            Name = "";
            Quantity = 0;
            Ingredient = null;
            Category = null;
        }
        public Grocery(int id, string? barcode, string name, int quantity, string? ingredient, string? category)
        {
            Id = id;
            Barcode = barcode;
            Name = name;
            Quantity = quantity;
            Ingredient = ingredient;
            Category = category;
        }
        #endregion

    }
}
