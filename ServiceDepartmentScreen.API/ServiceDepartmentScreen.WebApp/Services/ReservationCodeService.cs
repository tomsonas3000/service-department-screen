﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
            return await JsonSerializer.DeserializeAsync<ReservationCode>(
                await _httpClient.GetStreamAsync($"api/reservationcode/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<ReservationCode>> GetCodesBySpecialistId(int specialistId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ReservationCode>>(
                await _httpClient.GetStreamAsync($"api/reservationcode/specialist/{specialistId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}