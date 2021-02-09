using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.WebApp.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly HttpClient _httpClient;

        public SpecialistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Login(Specialist specialist)
        {
            await _httpClient.PostAsJsonAsync<Specialist>("api/specialist/login", specialist);
        }

        public async Task<Specialist> GetSpecialistById(int id)
        {
            var response = await _httpClient.GetAsync($"api/specialist/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var specialist = JsonSerializer.Deserialize<Specialist>(response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return specialist;
        }
    }
}
