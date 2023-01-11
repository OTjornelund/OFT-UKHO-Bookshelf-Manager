using Microsoft.AspNetCore.Mvc;
using OFT_UKHO_Bookshelf_Manager.Models;

namespace OFT_UKHO_Bookshelf_Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class X_WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<X_WeatherForecastController> _logger;

        public X_WeatherForecastController(ILogger<X_WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<X_WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new X_WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}