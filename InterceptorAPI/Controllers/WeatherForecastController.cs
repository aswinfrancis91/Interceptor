using InterceptorAPI.Model;
using Microsoft.AspNetCore.Mvc;
using ProxyAttributes;

namespace InterceptorAPI.Controllers
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
        private readonly IStudent _student;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudent student)
        {
            _logger = logger;
            _student = student;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //Info: Debugger will go into hook but wouldn't execute anything as this method isnt marked with the custom attribute
            _student.SetName("MyName");
            //Info: Debugger will go into hook and execute our code since the hook attribute was added here
            var firstCharacter = _student.GetFirstLetterOfName();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}