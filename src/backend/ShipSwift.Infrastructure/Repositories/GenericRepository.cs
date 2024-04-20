using Microsoft.EntityFrameworkCore;
using ShipSwift.CoreBusiness;

namespace ShipSwift.Infrastructure;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        return await Task.FromResult(_dbSet.Add(entity).Entity);
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => _dbSet.Remove(entity));
    }

    public async Task<List<T>> ExecuteMultipleResultsStoredProcAsync(string storedProcName, params string[] parameters)
    {
        return await _dbSet.FromSqlRaw(storedProcName, parameters).ToListAsync();
    }

    public async Task<T?> ExecuteSingleResultStoredProcAsync(string storedProcName, params string[] parameters)
    {
        return await _dbSet.FromSqlRaw(storedProcName, parameters).FirstOrDefaultAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() => _dbSet.Update(entity));
    }
}
