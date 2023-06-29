using Contracts;

namespace Services.Abstraction;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecastDto>> GetAllAsync();
    Task AddAsync(WeatherForecastDto weatherForecastDto);
    Task UpdateASync(WeatherForecastDto weatherForecastDto);
    Task DeleteAsync(WeatherForecastDto weatherForecastDto);
    Task<WeatherForecastDto> GetWeatherByIdAsync(int id);
}