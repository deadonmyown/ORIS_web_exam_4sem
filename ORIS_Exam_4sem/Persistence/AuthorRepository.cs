using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        return await _dbContext.Authors.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(Author author)
    {
        _dbContext.Authors.Add(author);

        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author author)
    {
        var authorDb = _dbContext.Authors.FirstOrDefault(u => u.Id == author.Id);
        if (authorDb is null)
            throw new Exception("author not found");
        _dbContext.Entry(authorDb).CurrentValues.SetValues(author);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author author)
    {
        _dbContext.Authors.Remove(author);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        return await _dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }
}