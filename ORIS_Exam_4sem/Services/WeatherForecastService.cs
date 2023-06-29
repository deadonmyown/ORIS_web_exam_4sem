using Contracts;
using Domain.Entity;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public WeatherForecastService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<WeatherForecastDto>> GetAllAsync()
    {
        var entities = await _unitOfWork.WeatherForecastRepository.GetAllAsync();
        return entities.Select(e => new WeatherForecastDto()
        {
            Id = e.Id,
            CreationDate = e.CreationDate,
            Date = e.Date,
            AuthorId = e.AuthorId,
            City = e.City,
            Summary = e.Summary,
            TemperatureC = e.TemperatureC
        });
    }

    public async Task AddAsync(WeatherForecastDto weatherForecastDto)
    {
        await _unitOfWork.WeatherForecastRepository.AddAsync(new WeatherForecast()
        {
            Id = weatherForecastDto.Id,
            CreationDate = weatherForecastDto.CreationDate,
            Date = weatherForecastDto.Date,
            AuthorId = weatherForecastDto.AuthorId,
            City = weatherForecastDto.City,
            Summary = weatherForecastDto.Summary,
            TemperatureC = weatherForecastDto.TemperatureC
        });
    }

    public async Task UpdateASync(WeatherForecastDto weatherForecastDto)
    {
        await _unitOfWork.WeatherForecastRepository.UpdateAsync(new WeatherForecast()
        {
            Id = weatherForecastDto.Id,
            CreationDate = weatherForecastDto.CreationDate,
            Date = weatherForecastDto.Date,
            AuthorId = weatherForecastDto.AuthorId,
            City = weatherForecastDto.City,
            Summary = weatherForecastDto.Summary,
            TemperatureC = weatherForecastDto.TemperatureC
        });
    }

    public async Task DeleteAsync(WeatherForecastDto weatherForecastDto)
    {
        await _unitOfWork.WeatherForecastRepository.DeleteAsync(new WeatherForecast()
        {
            Id = weatherForecastDto.Id,
            CreationDate = weatherForecastDto.CreationDate,
            Date = weatherForecastDto.Date,
            AuthorId = weatherForecastDto.AuthorId,
            City = weatherForecastDto.City,
            Summary = weatherForecastDto.Summary,
            TemperatureC = weatherForecastDto.TemperatureC
        });
    }

    public async Task<WeatherForecastDto> GetWeatherByIdAsync(int id)
    {
        var weatherForecast = await _unitOfWork.WeatherForecastRepository.GetWeatherByIdAsync(id);
        return new WeatherForecastDto()
        {
            Id = weatherForecast.Id,
            CreationDate = weatherForecast.CreationDate,
            Date = weatherForecast.Date,
            AuthorId = weatherForecast.AuthorId,
            City = weatherForecast.City,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        };
    }
}