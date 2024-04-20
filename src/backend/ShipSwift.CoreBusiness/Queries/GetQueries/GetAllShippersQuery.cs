using MediatR;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.CoreBusiness;

public record GetAllShippersQuery() : IRequest<List<Shipper>>;