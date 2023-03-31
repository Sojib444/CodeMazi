using Contract;
using Microsoft.AspNetCore.Mvc;

namespace CodeMaze.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private  ILoggerManager _loggermanager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger ,ILoggerManager loggermanager)
        {
            _logger = logger;
            _loggermanager = loggermanager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _loggermanager.LogInfo("This is get Page");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}