using katori.DTO;
using katori.Interfaces;
using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticularController : ControllerBase
    {
        private readonly IParticularRepository _repository;
        public ParticularController(IParticularRepository repository) { _repository = repository; }

        [HttpGet("getParticulars")]
        public async Task<ActionResult<List<Particular>>> GetParticulars()
        {
            var particulars = await _repository.GetAll();

            if (particulars is null)
            {
                return NotFound();
            }

            return Ok(particulars);
        }

        //create new particular
        [HttpPost("setParticular")]
        public async Task<ActionResult> setParticular([FromBody] ParticularDTO dto)
        {
            return Ok();
        }
    }
}
