using System.Net.Http.Json;
using MediatR;

namespace ShipSwift.CoreBusiness;

public class GetRandomQuoteQueryHandler : IRequestHandler<GetRandomQuoteQuery, Quote?>
{
    public Task<Quote?> Handle(GetRandomQuoteQuery request, CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        return client.GetFromJsonAsync<Quote>("https://api.quotable.io/random");
    }
}
