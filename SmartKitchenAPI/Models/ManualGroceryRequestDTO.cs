namespace SmartKitchenAPI.Models
{
    public record ManualGroceryRequestDTO(
        string Name,
        string Ingredient,
        int Quantity
    )
    {
    }
}
