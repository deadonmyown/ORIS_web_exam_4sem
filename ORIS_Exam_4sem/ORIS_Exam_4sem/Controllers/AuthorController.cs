using Contracts;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;

namespace ORIS_Exam_4sem.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    private readonly ILogger<WeatherForecastController> _logger;

    public AuthorController(ILogger<WeatherForecastController> logger,IServiceManager serviceManager)
    {
        _logger = logger;
        _serviceManager = serviceManager;
    }
    
    [HttpGet(Name = "GetAuthor")]
    public async Task<IEnumerable<Author>> Get()
    {
        return (await _serviceManager.AuthorService.GetAllAsync()).Select(a => new Author()
        {
            Id = a.Id,
            Name = a.Name
        });
    }
    
    [HttpPost("addAuthor")]
    public async Task<IActionResult> AddAuthor([FromBody] Author author)
    {
        await _serviceManager.AuthorService.AddAsync(new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name
        });
        return Ok();
    }
    
    [HttpPut("updateAuthor")]
    public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
    {
        await _serviceManager.AuthorService.UpdateAsync(new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name
        });
        return Ok();
    }
    
    [HttpDelete("deleteAuthor")]
    public async Task<IActionResult> DeleteAuthor([FromBody] Author author)
    {
        await _serviceManager.AuthorService.DeleteAsync(new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name
        });
        return Ok();
    }
}