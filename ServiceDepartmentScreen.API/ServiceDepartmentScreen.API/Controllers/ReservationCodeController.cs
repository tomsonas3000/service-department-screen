﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ServiceDepartmentScreen.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
