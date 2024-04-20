using Microsoft.EntityFrameworkCore;
using ShipSwift.CoreBusiness;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.Infrastructure;

public class ShippersRepository : IGenericRepository<Shipper>
{
    private readonly AppDbContext _context;
    private DbSet<Shipper> _dbSet;

    public ShippersRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<Shipper>();
    }

    public async Task<Shipper> AddAsync(Shipper entity)
    {
        return await Task.FromResult(_dbSet.Add(entity).Entity);
    }

    public async Task DeleteAsync(Shipper entity)
    {
        await Task.Run(() => _dbSet.Remove(entity));
    }

    public async Task<List<Shipper>> ExecuteMultipleResultsStoredProcAsync(string storedProcName, params string[] parameters)
    {
        return await _context.Shippers.FromSqlRaw(storedProcName, parameters).ToListAsync();
    }

    public async Task<Shipper?> ExecuteSingleResultStoredProcAsync(string storedProcName, params string[] parameters)
    {
        return await _context.Shippers.FromSqlRaw(storedProcName, parameters).FirstOrDefaultAsync();
    }

    public async Task<Shipper?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<Shipper>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(Shipper entity)
    {
        await Task.Run(() => _dbSet.Update(entity));
    }
}
