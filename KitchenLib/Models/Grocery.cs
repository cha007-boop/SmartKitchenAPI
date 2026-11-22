namespace KitchenLib.Models
{
    public class Grocery
    {
        #region Properties
        public int Id { get; set; }
        public string? Barcode { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string? IngredientStr { get; set; }
        public string? Category { get; set; }
        #endregion

        #region Constructors
        public Grocery()
        {
            Id = 0;
            Barcode = "";
            Name = "";
            IngredientStr = null;
            Category = null;
        }
        public Grocery(int id, string? barcode, string name, int? ingredientTypeId, string? category)
        {
            Id = id;
            Barcode = barcode;
            Name = name;
            IngredientStr = ingredientTypeId;
            Category = category;
        }
        #endregion

    }
}
