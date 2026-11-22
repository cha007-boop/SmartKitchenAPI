using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Models
{
    public class ScanRequest
    {
        public string Barcode { get; set; }
        public ScanMode Mode { get; set; }
    }
}
