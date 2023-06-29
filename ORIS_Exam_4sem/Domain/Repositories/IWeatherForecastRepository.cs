using Domain.Entity;

namespace Domain.Repositories;

public interface IWeatherForecastRepository
{
    Task<IEnumerable<WeatherForecast>> GetAllAsync();
    Task AddAsync(WeatherForecast weather);
    Task UpdateAsync(WeatherForecast weather);
    Task DeleteAsync(WeatherForecast weather);
    Task<WeatherForecast> GetWeatherByIdAsync(int id);
}