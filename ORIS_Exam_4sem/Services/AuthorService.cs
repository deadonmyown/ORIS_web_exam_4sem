using System.Collections.ObjectModel;
using Contracts;
using Domain.Entity;
using Domain.Repositories;
using Services.Abstraction;

namespace Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<AuthorDto>> GetAllAsync()
    {
        var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
        return authors.Select(a => new AuthorDto()
        {
            Id = a.Id,
            Name = a.Name
        });
    }

    public async Task AddAsync(AuthorDto authorDto)
    {
        await _unitOfWork.AuthorRepository.AddAsync(new Author()
        {
            Id = authorDto.Id,
            Name = authorDto.Name
        });
    }

    public async Task UpdateAsync(AuthorDto authorDto)
    {
        await _unitOfWork.AuthorRepository.UpdateAsync(new Author()
        {
            Id = authorDto.Id,
            Name = authorDto.Name
        });
    }

    public async Task DeleteAsync(AuthorDto authorDto)
    {
        await _unitOfWork.AuthorRepository.DeleteAsync(new Author()
        {
            Id = authorDto.Id,
            Name = authorDto.Name
        });
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        var author = await _unitOfWork.AuthorRepository.GetAuthorByIdAsync(id);
        var wfDto = new List<WeatherForecastDto>();

        return new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name,
        };
    }
}