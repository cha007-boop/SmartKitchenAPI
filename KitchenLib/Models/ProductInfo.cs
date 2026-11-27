using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenLib.Models
{
    public sealed class ProductInfo
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Categories { get; set; }
    }
}
