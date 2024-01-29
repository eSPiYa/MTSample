using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningFromController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public RunningFromController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var runningFrom = this.configuration.GetValue<string>("RunningFrom");
            return Ok(runningFrom);
        }
    }
}
