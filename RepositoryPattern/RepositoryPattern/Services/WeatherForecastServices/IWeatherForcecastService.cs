namespace RepositoryPattern.Services.WeatherForecastServices
{
    public interface IWeatherForcecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
