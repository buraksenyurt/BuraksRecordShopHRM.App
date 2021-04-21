using BuraksRecordShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuraksRecordShopHRM.App.Services
{
    public class EmployeeDataService
        : IEmployeeDataService
    {
        /*
            Program sınıfındaki DI Servis register işlemi gereği HttpClient hangi servis adresini kullanacağını bilir.
        */
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> Create(Employee employee)
        {
            // Employee nesnesini JSON olarak serileştir
            var payload =new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            // HTTP Post işlemini api/employee adresine doğru icra et. Mesaj gövdesinde serileştirilmiş içerik gider
            var response = await _httpClient.PostAsync("api/employee", payload);
            if (response.IsSuccessStatusCode) // HTTP 200 Ok cevabı geldiyse
            {
                // cevap içeriğini Employee nesnesine dönüştür
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var response = await _httpClient.GetStreamAsync($"api/employee");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(response,options);
        }

        public async Task<Employee> GetDetail(int id)
        {
            var response = await _httpClient.GetStreamAsync($"api/employee/{id}");
            return await JsonSerializer.DeserializeAsync<Employee>(response, options);
        }

        public async Task Update(Employee employee)
        {
            var payload =new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/employee", payload);
        }
    }
}
