using Domain.Repositories;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IAuthorRepository> _lazyAuthorRepository;
    private readonly Lazy<IWeatherForecastRepository> _lazyWeatherRepository;
    
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _lazyAuthorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(dbContext));
        _lazyWeatherRepository = new Lazy<IWeatherForecastRepository>(() => new WeatherForecastRepository(dbContext));
    }

    public IAuthorRepository AuthorRepository => _lazyAuthorRepository.Value;
    public IWeatherForecastRepository WeatherForecastRepository => _lazyWeatherRepository.Value;
}