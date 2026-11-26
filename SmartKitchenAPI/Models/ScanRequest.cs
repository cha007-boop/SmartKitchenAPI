using KitchenLib.Models;

namespace SmartKitchenAPI.Models
{
    public class ScanRequest
    {
        public string Barcode { get; set; }
        public ScanMode Mode { get; set; }
    }
}
