using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.WebApp.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var currentSpecialist = await _httpClient.GetFromJsonAsync<Specialist>("api/specialist/current");
            if (currentSpecialist?.Username != null)
            {
                var claim = new Claim(ClaimTypes.Name, Convert.ToString(currentSpecialist.SpecialistId));
                var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
