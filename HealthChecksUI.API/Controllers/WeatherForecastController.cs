using Microsoft.AspNetCore.Mvc;

namespace HealthChecksUI.API.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok("test");
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test([FromBody] TestModel model) 
        {
            return Ok(model);
        }
    }

    public class TestModel
    {
        public int Id { get; set; }
    }
}