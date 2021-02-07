using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.WebApp.Services
{
    public class ReservationCodeService : IReservationCodeService
    {
        private readonly HttpClient _httpClient;

        public ReservationCodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ReservationCode>> GetActiveCodes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ReservationCode>>(
                await _httpClient.GetStreamAsync($"api/reservationcode/active"),
                new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }

        public async Task<IEnumerable<ReservationCode>> GetUpcomingCodes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ReservationCode>>(
                await _httpClient.GetStreamAsync($"api/reservationcode/upcoming"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ReservationCode> GetCodeById(int id)
        {
            var response = await _httpClient.GetAsync($"api/reservationcode/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var code = JsonSerializer.Deserialize<ReservationCode>(response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return code;
        }

        public async Task<IEnumerable<ReservationCode>> GetCodesBySpecialistId(int specialistId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ReservationCode>>(
                await _httpClient.GetStreamAsync($"api/reservationcode/specialist/{specialistId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ReservationCode> GenerateNewCode()
        {
            var response = await _httpClient.PostAsync("api/reservationcode/new", null);
            if (!response.IsSuccessStatusCode) return null;
            var generatedCode = JsonSerializer.Deserialize<ReservationCode>(response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return generatedCode;
        }

        public async Task<ReservationCode> UpdateStatus(int id, Status status)
        {
            var statusJson = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/reservationcode/update/{id}", statusJson);
            if (!response.IsSuccessStatusCode) return null;
            var updatedCode = JsonSerializer.Deserialize<ReservationCode>(response.Content.ReadAsStringAsync().Result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return updatedCode;
        }
    }
}
