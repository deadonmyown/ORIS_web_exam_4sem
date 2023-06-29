using Contracts;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace ORIS_Exam_4sem.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,IServiceManager serviceManager)
    {
        _logger = logger;
        _serviceManager = serviceManager;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var entities = (await _serviceManager.WeatherForecastService.GetAllAsync()).Select(weatherForecastDto => new WeatherForecast()
        {
            Id = weatherForecastDto.Id,
            CreationDate = weatherForecastDto.CreationDate,
            Date = weatherForecastDto.Date,
            AuthorId = weatherForecastDto.AuthorId,
            City = weatherForecastDto.City,
            Summary = weatherForecastDto.Summary,
            TemperatureC = weatherForecastDto.TemperatureC
        });
        return entities;
    }
    
    [HttpPost("addWeatherForecast")]
    public async Task<IActionResult> AddWeatherForecast([FromBody] WeatherForecast weatherForecast)
    {
        await _serviceManager.WeatherForecastService.AddAsync(new WeatherForecastDto()
        {
            Id = weatherForecast.Id,
            CreationDate = weatherForecast.CreationDate,
            Date = weatherForecast.Date,
            AuthorId = weatherForecast.AuthorId,
            City = weatherForecast.City,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        });
        return Ok();
    }
    
    [HttpPut("updateWeatherForecast")]
    public async Task<IActionResult> UpdateWeatherForecast([FromBody] WeatherForecast weatherForecast)
    {
        await _serviceManager.WeatherForecastService.UpdateASync(new WeatherForecastDto()
        {
            Id = weatherForecast.Id,
            CreationDate = weatherForecast.CreationDate,
            Date = weatherForecast.Date,
            AuthorId = weatherForecast.AuthorId,
            City = weatherForecast.City,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        });
        return Ok();
    }
    
    [HttpDelete("deleteWeatherForecast")]
    public async Task<IActionResult> DeleteWeatherForecast([FromBody] WeatherForecast weatherForecast)
    {
        await _serviceManager.WeatherForecastService.DeleteAsync(new WeatherForecastDto()
        {
            Id = weatherForecast.Id,
            CreationDate = weatherForecast.CreationDate,
            Date = weatherForecast.Date,
            AuthorId = weatherForecast.AuthorId,
            City = weatherForecast.City,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        });
        return Ok();
    }
}