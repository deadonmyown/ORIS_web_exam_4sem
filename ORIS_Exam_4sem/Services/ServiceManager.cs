using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthorService> _lazyAuthorService;
    private readonly Lazy<IWeatherForecastService> _lazyWeatherForecastService;

    public ServiceManager(IUnitOfWork unitOfWork)
    {
        _lazyAuthorService = new Lazy<IAuthorService>(() => new AuthorService(unitOfWork));
        _lazyWeatherForecastService = new Lazy<IWeatherForecastService>(() => new WeatherForecastService(unitOfWork));
    }

    public IAuthorService AuthorService => _lazyAuthorService.Value;
    public IWeatherForecastService WeatherForecastService => _lazyWeatherForecastService.Value;
}