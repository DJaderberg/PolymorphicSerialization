using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolymorphicSerialization.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            var rng = new Random();
            var temp = rng.Next(-20, 55);
            var result = new SecretWeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = temp + rng.Next(-10, 10),
                Summary = Summaries[rng.Next(Summaries.Length)],
                ActualTemperatureC = temp
            };

            return result;
        }
    }
}
