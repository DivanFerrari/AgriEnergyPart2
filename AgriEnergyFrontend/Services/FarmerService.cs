using AgriEnergyFrontend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AgriEnergyFrontend.Services
{
    public class FarmerService
    {
        private readonly HttpClient _httpClient;

        public FarmerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Farmer>> GetAllFarmersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://api-service:8081/api/farmer");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    throw new Exception("Response content is empty");
                }

                return JsonConvert.DeserializeObject<List<Farmer>>(content) ?? new List<Farmer>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occurred while fetching farmer from the API.", ex);
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
