using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ServiceDepartmentScreen.API.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ServiceDepartmentScreen.Shared;

namespace ServiceDepartmentScreen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
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

        [HttpPost("login")]
        public async Task<ActionResult<Specialist>>Login(Specialist specialist)
        {
            Specialist checkedSpecialist = await _specialistRepository.CheckCredentials(specialist);
            if (checkedSpecialist != null)
            {
                var claim = new Claim(ClaimTypes.Name, checkedSpecialist.Username);
                var claimsIdentity = new ClaimsIdentity(new[] {claim}, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
            }
            return checkedSpecialist;
        }

        [HttpGet("loggedin")]
        public async Task<ActionResult<Specialist>> GetLoggedIn()
        {
            Specialist loggedInSpecialist = new Specialist();
            if (User.Identity.IsAuthenticated)
            {
                loggedInSpecialist.Username = User.FindFirstValue(ClaimTypes.Name);
            }
            return await Task.FromResult(loggedInSpecialist);
        }
    }
}
