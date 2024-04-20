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
        var query = $"EXECUTE Shipper_Shipment_Details {shipperId}";
        var shipper = _context.Shippers
            .FromSqlRaw(query)
            .ToList();

        shipper.ForEach(s =>
        {
            _context.Entry(s)
                .Collection(b => b.Shipments)
                .Query()
                .Include(b => b.Carrier)
                .Include(b => b.ShipmentRate)
                .Load();
        });

        return await Task.FromResult(shipper.FirstOrDefault());
    }
}
