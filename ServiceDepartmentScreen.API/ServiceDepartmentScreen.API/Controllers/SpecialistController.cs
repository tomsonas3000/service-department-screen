using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ServiceDepartmentScreen.API.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialist>> GetSpecialistById(int id)
        {
            try
            {
                var result = await _specialistRepository.GetSpecialistById(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
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

        [HttpPost("logout")]
        public async Task<ActionResult<String>> LogoutUser()
        {
            await HttpContext.SignOutAsync();
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpGet("current")]
        public async Task<ActionResult<Specialist>> GetCurrentSpecialist()
        {
            Specialist currentSpecialist = new Specialist();
            if (User.Identity.IsAuthenticated)
            {
                currentSpecialist.Username = User.FindFirstValue(ClaimTypes.Name);
            }
            return await Task.FromResult(currentSpecialist);
        }

    }
}
