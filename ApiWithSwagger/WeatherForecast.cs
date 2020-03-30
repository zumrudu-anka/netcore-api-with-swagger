using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiWithSwagger
{
    /// <summary>
    /// Class which auto added by api
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Forecast Date
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        #pragma warning disable CS1591
        public int TemperatureC { get; set; }

        #pragma warning restore CS1591
        /// <summary>
        /// Temperature from fahrenheit
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Summary
        /// </summary>
        [DefaultValue(false)]
        public string Summary { get; set; }
    }
}
