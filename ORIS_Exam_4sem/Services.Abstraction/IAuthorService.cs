using Contracts;

namespace Services.Abstraction;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAsync();
    Task AddAsync(AuthorDto authorDto);
    Task UpdateAsync(AuthorDto authorDto);
    Task DeleteAsync(AuthorDto authorDto);
    Task<AuthorDto> GetAuthorByIdAsync(int id);
}