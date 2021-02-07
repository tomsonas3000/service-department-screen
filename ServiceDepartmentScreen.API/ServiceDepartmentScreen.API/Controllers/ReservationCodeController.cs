using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
    public class ReservationCodeController : ControllerBase
    {
        private readonly IReservationCodeRepository _codeRepository;
        public ReservationCodeController(IReservationCodeRepository codeRepository)
        {
            _codeRepository = codeRepository;
        }
        [HttpGet("upcoming")]
        public async Task<ActionResult<ReservationCode[]>> GetUpcomingCodes()
        {
            try
            {
                return await _codeRepository.GetUpcomingCodes(); ;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }
        [HttpGet("active")]
        public async Task<ActionResult<ReservationCode[]>> GetActiveCodes()
        {
            try
            {
                return await _codeRepository.GetActiveCodes(); ;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationCode>> GetCodeById(int id)
        {
            try
            {
                return await _codeRepository.GetCodeById(id); ;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }
        [HttpGet("specialist/{id}")]
        public async Task<ActionResult<ReservationCode[]>> GetCodeBySpecialistId(int id)
        {
            try
            {
                return await _codeRepository.GetCodesBySpecialistId(id); ;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }
        [HttpPost("new")]
        public async Task<ActionResult<ReservationCode>> GenerateNewCode()
        {
            try
            {
                var newCode = _codeRepository.GenerateNewCode();
                if (await _codeRepository.SaveChangesAsync())
                {
                    return Created($"api/reservationcode/{newCode.ReservationCodeId}", newCode);
                }
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }

            return BadRequest();
        }

        [HttpPut("update/{codeId}")]
        public async Task<ActionResult<ReservationCode>> UpdateStatusOfCode(int codeId, Status status)
        {
            try
            {
                var oldCode = await _codeRepository.GetCodeById(codeId);
                if (oldCode == null) return NotFound($"Could not find code with this ID {codeId}");
                if (status == Status.Active && await _codeRepository.CheckIfActiveBySpecialist(oldCode.SpecialistId))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "The specialist already has an active visit");
                }
                var newCode = await _codeRepository.UpdateStatus(codeId, status);
                return newCode;
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal database error");
            }
        }
    }
}
