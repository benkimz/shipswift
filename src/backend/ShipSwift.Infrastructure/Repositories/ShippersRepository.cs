using Microsoft.EntityFrameworkCore;
using ShipSwift.CoreBusiness;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.Infrastructure;

public class ShippersRepository : IShippersRepository
{
    private readonly AppDbContext _context;
    private readonly IGenericRepository<Shipper> _repository;

    public ShippersRepository(AppDbContext context, IGenericRepository<Shipper> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<List<Shipper>> GetAllShippersAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Shipper?> GetShipperShipmentDetailsAsync(int shipperId)
    {
        var shipper = _context.Shippers
            .Include(s => s.Shipments).ThenInclude(s => s.Carrier)
            .Include(s => s.Shipments).ThenInclude(s => s.ShipmentRate)
            .Where(s => s.ShipperId == shipperId).FirstOrDefault();

        return await Task.FromResult(shipper);
    }
}
