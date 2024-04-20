using MediatR;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public class GetShipperShipmentDetailsQueryHandler : IRequestHandler<GetShipperShipmentDetailsQuery, Shipper?>
{
    private readonly IShippersRepository _shipperRepository;

    public GetShipperShipmentDetailsQueryHandler(IShippersRepository shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public async Task<Shipper?> Handle(GetShipperShipmentDetailsQuery request, CancellationToken cancellationToken) => await _shipperRepository.GetShipperShipmentDetailsAsync(request.shipper_id);
}
