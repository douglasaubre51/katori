using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestResult()
        {
            return Ok("katori says hello!");
        }
    }
}
