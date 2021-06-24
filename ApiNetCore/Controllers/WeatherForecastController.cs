using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNetCore.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, Summaries.Length - 1).Select(idx => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(idx),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var rng = new Random();
            return Enumerable.Range(0, Summaries.Length - 1).Select(idx => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(idx),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .FirstOrDefault();
        }

        [HttpPost]
        public void Post([FromBody] WeatherForecast obj)
        {
            _logger.Log(LogLevel.Debug, $"C: {obj.TemperatureC}, F: {obj.TemperatureF}");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WeatherForecast obj)
        {
            _logger.Log(LogLevel.Debug, $"id: {id}, C: {obj.TemperatureC}, F: {obj.TemperatureF}");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.Log(LogLevel.Debug, $"id: {id}");
        }
    }
}