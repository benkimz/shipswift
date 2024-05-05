using System.Net.Http.Json;
using System.Text.Json;
using MediatR;

namespace ShipSwift.CoreBusiness;

public class GetGroupedQuotesByAuthorQueryHandler : IRequestHandler<GetGroupedQuotesByAuthorQuery, GroupedQuotes>
{
    public async Task<GroupedQuotes> Handle(GetGroupedQuotesByAuthorQuery request, CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        var url = new UriBuilder("https://api.quotable.io/quotes")
        {
            Query = $"author={request.Author}&limit={request.Limit}"
        }
        .ToString();
        
        var response = await client.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<JsonElement>(json).GetProperty("results")
            .EnumerateArray()
            .Select(quote => new Quote(
                Author: quote.GetProperty("author").GetString() ?? string.Empty,
                Content: quote.GetProperty("content").GetString() ?? string.Empty
            ))
            .ToList();

        GroupedQuotes quotes = new([],[],[]);

        if(results is not null)
        {
            await Task.Run(() => {
                results.ForEach(quote => {
                    var words = quote.Content.Split(' ').Length;
                    if(words < 10){
                        quotes.ShortQuotes.Add(quote);
                    } else if(words > 10 && words < 20){
                        quotes.MediumQuotes.Add(quote);
                    } else {
                        quotes.LongQuotes.Add(quote);
                    }
                });
            });
        }
        return quotes;
    }
}
