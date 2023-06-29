using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WeatherForecastRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<WeatherForecast>> GetAllAsync()
    {
        return await _dbContext.WeatherForecasts.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(WeatherForecast weather)
    {
        _dbContext.WeatherForecasts.Add(weather);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(WeatherForecast weather)
    {
        var weatherForecastDb = _dbContext.WeatherForecasts.FirstOrDefault(u => u.Id == weather.Id);
        if (weatherForecastDb is null)
            throw new Exception("weatherForecast not found");
        _dbContext.Entry(weatherForecastDb).CurrentValues.SetValues(weather);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(WeatherForecast weather)
    {
        _dbContext.WeatherForecasts.Remove(weather);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<WeatherForecast> GetWeatherByIdAsync(int id)
    {
        return await _dbContext.WeatherForecasts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }
}