using KitchenLib.Models;

namespace SmartKitchenAPI.Models
{
    public record ScanRequestDTO(
        string Barcode,
        ScanMode Mode
    )
    {
    }
}
