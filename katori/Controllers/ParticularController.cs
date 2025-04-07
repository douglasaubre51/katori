using katori.Dto;
using katori.Interfaces;
using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticularController : ControllerBase
    {
        private readonly IParticularRepository _particularRepository;
        private readonly ILedgerRepository _ledgerRepository;

        public ParticularController(ILedgerRepository ledgerRepository, IParticularRepository particularRepository)
        {
            _ledgerRepository = ledgerRepository;
            _particularRepository = particularRepository;
        }

        [HttpGet("getParticulars")]
        public async Task<ActionResult<List<Particular>>> GetParticulars()
        {
            var particulars = await _particularRepository.GetAll();

            if (particulars is null)
            {
                return NotFound();
            }

            return Ok(particulars);
        }

        //get dr and cr side of ledger
        [HttpGet("getParticularsOfLedger")]
        public async Task<ActionResult<ParticularDto>> GetParticularsOfLedger(string ledgerName)
        {
            var validate = await _ledgerRepository.GetByTitle(ledgerName);

            if (validate is null)
                return BadRequest();

	    await _ledgerRepository.SetSumOfParticulars(ledgerName);

            var debitParticulars = await _particularRepository.GetDebitParticularsByTitle(ledgerName);

            var creditParticulars = await _particularRepository.GetCreditParticularsByTitle(ledgerName);

            var dto = new ParticularDto()
            {
                DebitParticulars = debitParticulars,
                CreditParticulars = creditParticulars
            };

            return Ok(dto);
        }
    }
}
