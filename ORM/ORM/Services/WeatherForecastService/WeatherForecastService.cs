using ORM.Data;

namespace ORM.Services.WeatherForecastService
{
    public class WeatherForecastService : IWeatherForecastService
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly DataContext _context;

        public WeatherForecastService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            return _context.Forecasts.ToArray();
        }
    }
}
