using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Services.WeatherForecastServices;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForcecastService _weatherForcecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForcecastService weatherForcecastService)
        {
            _logger = logger;
            _weatherForcecastService = weatherForcecastService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForcecastService.Get();
        }
    }
}