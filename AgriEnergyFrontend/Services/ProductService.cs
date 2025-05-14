using AgriEnergyFrontend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AgriEnergyFrontend.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://api-product-service:8080/api/product");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new Exception("Response content is empty");
                }

                return JsonConvert.DeserializeObject<List<Product>>(content) ?? new List<Product>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occurred while fetching cows from the API.", ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new Exception("An error occurred while deserializing the response.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }


        }
    }
}
