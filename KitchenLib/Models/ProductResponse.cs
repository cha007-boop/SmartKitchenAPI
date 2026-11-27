using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KitchenLib.Models
{
    public sealed class ProductResponse
    {
        [JsonPropertyName("product_name_en")]
        public string? Name { get; set; }

        [JsonPropertyName("_keywords")]
        public List<string> Keywords { get; set; } = [];

        [JsonPropertyName("brands")]
        public string? Brands { get; set; }

        [JsonPropertyName("categories_tags")]
        public List<string> CategoriesTags { get; set; } = [];
    }
}
