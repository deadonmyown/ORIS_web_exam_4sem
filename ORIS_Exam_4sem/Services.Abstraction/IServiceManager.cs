namespace Services.Abstraction;

public interface IServiceManager
{
    IAuthorService AuthorService { get; }
    IWeatherForecastService WeatherForecastService { get; }
}