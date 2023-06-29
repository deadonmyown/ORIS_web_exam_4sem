namespace Domain.Repositories;

public interface IUnitOfWork
{
    IAuthorRepository AuthorRepository { get; }
    IWeatherForecastRepository WeatherForecastRepository { get; }
    
}