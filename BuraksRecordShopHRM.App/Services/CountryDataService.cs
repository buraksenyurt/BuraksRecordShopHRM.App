using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public class CountryDataService
        : ICountryDataService
    {
        public readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<Country>> GetAll()
        {
            var response = await _httpClient.GetStreamAsync("api/country");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(
                response,
                options);
        }

        public async Task<Country> GetById(int countryId)
        {
            var response = await _httpClient.GetStreamAsync($"api/country/{countryId}");
            return await JsonSerializer.DeserializeAsync<Country>(
                response,
                options);
        }
    }
}
