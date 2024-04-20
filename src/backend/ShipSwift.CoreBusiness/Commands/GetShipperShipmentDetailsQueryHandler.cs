using MediatR;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public class GetShipperShipmentDetailsQueryHandler : IRequestHandler<GetShipperShipmentDetailsQuery, Shipper>
{
    private readonly IGenericRepository<Shipper> _shipperRepository;

    public GetShipperShipmentDetailsQueryHandler(IGenericRepository<Shipper> shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public async Task<Shipper> Handle(GetShipperShipmentDetailsQuery request, CancellationToken cancellationToken) => await _shipperRepository.ExecuteSingleResultStoredProcAsync("Shipper_Shipment_Details", request.shipper_id.ToString());
}
