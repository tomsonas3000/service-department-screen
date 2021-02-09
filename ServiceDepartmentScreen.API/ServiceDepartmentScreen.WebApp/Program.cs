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
            builder.Services.AddTransient(sp =>
                new HttpClient {BaseAddress = new Uri("https://servicedepartmentscreenapi20210209173125.azurewebsites.net/") });
            builder.Services.AddHttpClient<IReservationCodeService, ReservationCodeService>(client =>
                client.BaseAddress = new Uri("https://servicedepartmentscreenapi20210209173125.azurewebsites.net/"));
            builder.Services.AddHttpClient<ISpecialistService, SpecialistService>(client =>
                client.BaseAddress = new Uri("https://servicedepartmentscreenapi20210209173125.azurewebsites.net/"));
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            await builder.Build().RunAsync();
        }
    }
}
