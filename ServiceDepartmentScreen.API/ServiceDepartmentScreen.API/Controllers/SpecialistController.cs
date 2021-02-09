using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ServiceDepartmentScreen.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController
    {
        private readonly ISpecialistRepository _specialistRepository;
        public SpecialistController(ISpecialistRepository specialistRepository)
        {
            _specialistRepository = specialistRepository;
        }
        [HttpGet]
        public async Task<ActionResult<Specialist[]>> GetSpecialists()
        {
            return await _specialistRepository.GetAllSpecialists();
        }
    }
}
