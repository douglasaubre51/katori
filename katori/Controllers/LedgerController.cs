using System.Threading.Tasks;
using katori.Dto;
using katori.Interfaces;
using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerRepository _repository;
        public LedgerController(ILedgerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("setLedger")]
        public async Task<ActionResult<Ledger>> SetLedger([FromBody] LedgerDto dto)
        {
            var tempLedger = await _repository.GetByTitle(dto.Title);

            if (tempLedger is null)
            {
                var ledger = new Ledger
                {
                    Title = dto.Title,
                    LedgerType = dto.LedgerType
                };

                var isAdded = _repository.Add(ledger);
                if (isAdded) return CreatedAtAction("SetLedger", ledger);

                return BadRequest("ledger not created!");
            }

            return BadRequest("ledger already exists!");
        }

        [HttpGet("getLedgerByTitle")]
        public async Task<ActionResult<Ledger>> GetLedgerByTitle(string title)
        {
            var ledger = await _repository.GetByTitle(title);
            if (ledger is null) return BadRequest("ledger doesnot exist!");

            bool result = await _repository.SetSumOfParticulars(title);

            ledger = await _repository.GetByTitle(title);

            return Ok(ledger);
        }

        [HttpGet("getLedgerTitles")]
        public async Task<ActionResult<List<string>>> GetLedgerTitles()
        {
            return Ok(await _repository.GetLedgersTitles() ?? null);
        }
    }
}
