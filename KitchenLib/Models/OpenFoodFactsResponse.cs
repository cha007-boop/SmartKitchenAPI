using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KitchenLib.Models
{
    public sealed class OpenFoodFactsResponse
    {
        [JsonPropertyName("product")]
        public ProductResponse? Product { get; set; }
    }
}
