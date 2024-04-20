using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public interface IShippersRepository
{
    Task<List<Shipper>> GetAllShippersAsync();
    Task<Shipper?> GetShipperShipmentDetailsAsync(int shipperId);
}
