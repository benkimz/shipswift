using MediatR;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public class GetAllShippersQueryHandler : IRequestHandler<GetAllShippersQuery, List<Shipper>>
{
    private readonly IGenericRepository<Shipper> _shipperRepository;

    public GetAllShippersQueryHandler(IGenericRepository<Shipper> shipperRepository)
    {
        _shipperRepository = shipperRepository;
    }

    public async Task<List<Shipper>> Handle(GetAllShippersQuery request, CancellationToken cancellationToken) => await _shipperRepository.ListAsync();
}
