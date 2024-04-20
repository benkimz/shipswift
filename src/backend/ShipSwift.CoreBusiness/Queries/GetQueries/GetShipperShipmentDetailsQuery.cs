using MediatR;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public record class GetShipperShipmentDetailsQuery(int shipperId) : IRequest<Shipper?>;