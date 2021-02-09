using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using ServiceDepartmentScreen.WebApp.Providers;
using ServiceDepartmentScreen.WebApp.Services;

namespace ServiceDepartmentScreen.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddHttpClient<IReservationCodeService, ReservationCodeService>(client =>
                client.BaseAddress = new Uri("http://localhost:5000/"));
            builder.Services.AddHttpClient<ISpecialistService, SpecialistService>(client =>
                client.BaseAddress = new Uri("http://localhost:5000/"));
            await builder.Build().RunAsync();
        }
    }
}
