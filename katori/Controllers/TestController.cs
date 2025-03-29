using Microsoft.AspNetCore.Mvc;

namespace katori.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("getTestResult")]
        public IActionResult GetTestResult()
        {
            return Ok("katori says hello!");
        }

        [HttpGet("getNewTestResult")]
        public IActionResult GetNewTestResult()
        {
            return Ok("katori says hello again!");
        }
    }
}
