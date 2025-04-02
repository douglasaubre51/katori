using katori.Dto;
using katori.Interfaces;
using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IParticularRepository _particularRepository;
        private readonly ILedgerRepository _ledgerRepository;
        public JournalController(IJournalRepository journalRepository, IParticularRepository particularRepository, ILedgerRepository ledgerRepository)
        {
            _journalRepository = journalRepository;
            _particularRepository = particularRepository;
            _ledgerRepository = ledgerRepository;
        }

        [HttpPost("setJournal")]
        public async Task<IActionResult> SetJournal([FromBody] JournalDto journal)
        {
            var ledger1 = await _ledgerRepository
            .GetByTitle(journal.Particular1);

            var ledger2 = await _ledgerRepository
            .GetByTitle(journal.Particular2);

            if ((ledger1 is not null) && (ledger2 is not null))
            {
                var newJournal = new Journal
                {
                    Particular1 = journal.Particular1,
                    Particular2 = journal.Particular2,
                    Comment = journal.Comment,
                    Debit = journal.Debit,
                    Credit = journal.Credit,
                    Date = journal.Date,
                };

                bool isJournalAdded = _journalRepository.Add(newJournal);
                bool isParticularCreated = await _particularRepository.CreateParticular(newJournal);

                if (isJournalAdded && isParticularCreated == true)
                    return CreatedAtAction("SetJournal", newJournal);

                return BadRequest("journal or particular couldnot be created!");
            }

            return BadRequest("particular 1 or particular 2 doesnot exists!");
        }

        [HttpGet("getJournals")]
        public async Task<ActionResult<List<Journal>>> GetJournals()
        {
            var journals = await _journalRepository.GetAll();

            if (journals is null)
            {
                return NotFound();
            }

            return Ok(journals);
        }
    }
}
