using katori.Models;
using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        [HttpPost("setLedger")]
        public async Task<ActionResult<Ledger>> SetLedger([FromBody] string title)
        {
            return Ok();
        }
    }
}
