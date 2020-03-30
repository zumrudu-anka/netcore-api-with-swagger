using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiWithSwagger.Controllers
{
    /// <summary>Weather Forecast Controller</summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        #pragma warning disable CS1591
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        #pragma warning restore CS1591

        /// <summary>
        /// Get All Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /WeatherForecast
        ///     [
        ///         {
        ///            "Date": "2020-03-31T04:18:06.4025848+03:00",
        ///             "temperatureC": 8,
        ///             "temperatureF": 46,
        ///             "summary": "Scorching"
        ///         },
        ///         {
        ///            "date": "2020-04-01T04:18:06.4028455+03:00",
        ///             "temperatureC": 38,
        ///             "temperatureF": 100,
        ///             "summary": "Bracing"
        ///         }
        ///     ]
        ///
        /// </remarks>
        /// <returns>List of WeatherForecast</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Get Specific Item
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id:int}")]
        public WeatherForecast Get(int id){
            var rng = new Random();
            return new WeatherForecast(){
                Date = DateTime.Now,
                Summary = Summaries[rng.Next(Summaries.Length)],
                TemperatureC = rng.Next(-20, 55)
            };
        }
    }
}
