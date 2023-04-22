namespace ORM.Services.WeatherForecastService
{
    public interface IWeatherForecastService
    {
        public IEnumerable<WeatherForecast> Get();
    }
}
