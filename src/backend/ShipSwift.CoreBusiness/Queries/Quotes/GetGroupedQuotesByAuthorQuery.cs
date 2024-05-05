using MediatR;

namespace ShipSwift.CoreBusiness;

public record class GetGroupedQuotesByAuthorQuery(string Author, int Limit=30) : IRequest<GroupedQuotes>;
