namespace SmartKitchenAPI.Models
{
    public record GroceryDTO(
        int Id,
        string Name,
        string? Barcode,
        int Quantity,
        string? Ingredient
        )
    {
    }
}
