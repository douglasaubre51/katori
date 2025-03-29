using katori.DTO;
using katori.Interfaces;
using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalRepository _repository;
        public JournalController(IJournalRepository repository) { _repository = repository; }

        [HttpPost("setJournal")]
        public IActionResult SetJournal([FromBody] JournalDTO journal)
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

            _repository.Add(newJournal);

            return Ok(newJournal);
        }

        [HttpGet("getJournals")]
        public async Task<ActionResult<List<Journal>>> GetJournals()
        {
            var journals = await _repository.GetAll();

            if (journals is null)
            {
                return NotFound();
            }

            return Ok(journals);
        }

    }
}
