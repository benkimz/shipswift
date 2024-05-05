using MediatR;

namespace ShipSwift.CoreBusiness;

public record GetRandomQuoteQuery() : IRequest<Quote?>;
