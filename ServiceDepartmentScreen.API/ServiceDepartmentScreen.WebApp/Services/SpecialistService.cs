using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDepartmentScreen.WebApp.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly HttpClient _httpClient;

        public SpecialistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
