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
        public ActionResult<Ledger> SetLedger([FromBody] LedgerDto dto)
        {
            var tempLedger = _repository.GetByTitle(dto.Title);

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
    }
}
