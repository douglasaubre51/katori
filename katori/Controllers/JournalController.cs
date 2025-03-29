using katori.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        [HttpGet("getRecords")]
        public async Task<List<Journal>> GetJournalRecords()
        {
            return null;
        }

    }
}
