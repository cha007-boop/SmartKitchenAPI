using KitchenLib.Interfaces;
using KitchenLib.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace KitchenLib.Services
{
    public class OpenFoodFactsService : IProductInfoProvider
    {
        private readonly HttpClient _httpClient;
        private static readonly SemaphoreSlim _requestGate = new(1, 1);
        private static readonly TimeSpan _requestInterval = TimeSpan.FromSeconds(6);
        private static DateTimeOffset _nextAllowedRequest = DateTimeOffset.MinValue;

        public OpenFoodFactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Make sure this is only called at most once every 6 seconds to avoid rate limiting issues with the OpenFoodFacts API.
        public async Task<ProductInfo?> GetByBarcodeAsync(string barcode)
        {
            await WaitForRateLimitAsync();

            OpenFoodFactsResponse? response =
                await _httpClient.GetFromJsonAsync<OpenFoodFactsResponse>(barcode + ".json");

            
            var keywords = response?.Product?.Keywords.Concat(response?.Product?.CategoriesTags ?? new List<string>()).ToList() ?? new List<string> { "Unknown" };


            return new ProductInfo
            {
                Barcode = barcode,
                Name = response?.Product?.Name ?? "Unknown",
                Brand = response?.Product?.Brands ?? "Unknown",
                Categories = string.Join(", ", keywords)
            };
        }

        private static async Task WaitForRateLimitAsync()
        {
            await _requestGate.WaitAsync();
            try
            {
                TimeSpan delay = _nextAllowedRequest - DateTimeOffset.UtcNow;
                if (delay > TimeSpan.Zero)
                {
                    await Task.Delay(delay);
                }

                _nextAllowedRequest = DateTimeOffset.UtcNow + _requestInterval;
            }
            finally
            {
                _requestGate.Release();
            }
        }

    }
}
