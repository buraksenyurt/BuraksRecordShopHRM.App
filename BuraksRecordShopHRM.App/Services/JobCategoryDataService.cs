using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public class JobCategoryDataService
        : IJobCategoryDataService
    {
        public readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<JobCategory>> GetAll()
        {
            var response = await _httpClient.GetStreamAsync("api/jobcategory");
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(
                response,
                options);
        }

        public async Task<JobCategory> GetById(int jobCategoryId)
        {
            var response = await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}");
            return await JsonSerializer.DeserializeAsync<JobCategory>(
                response,
                options);
        }
    }
}
