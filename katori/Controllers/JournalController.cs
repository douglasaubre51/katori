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
        public IActionResult SetJournal()
        {
            return Created();
        }

        [HttpGet("getJournals")]
        public async Task<List<Journal>> GetJournals()
        {
            var journals = await _repository.GetAll();

            if (journals is null)
            {
                return new List<Journal>();
            }

            return journals;
        }

    }
}
