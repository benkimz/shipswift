using Microsoft.EntityFrameworkCore;
using ShipSwift.CoreBusiness;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.Infrastructure;

public class ShippersRepository : IShippersRepository
{
    private readonly IGenericRepository<Shipper> _repository;

    public ShippersRepository(IGenericRepository<Shipper> repository)
    {
        _repository = repository;
    }

    public async Task<List<Shipper>> GetAllShippersAsync()
    {
        return await _repository.ListAsync();
    }

    public async Task<Shipper?> GetShipperShipmentDetailsAsync(int shipper_id)
    {
        return await _repository.ExecuteSingleResultStoredProcAsync(shipper_id.ToString());
    }
}
