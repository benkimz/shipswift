using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipSwift.CoreBusiness;

namespace ShipSwift.Api;

[ApiController]
[Route("api/shippers")]
[Consumes("application/json")]
[Produces("application/json")]
public class ShipSwiftController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShipSwiftController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/shippers")]
    public async Task<ActionResult> Get()
    {
        var shippers = await _mediator.Send(new GetAllShippersQuery());
        return shippers is null ? NotFound() : Ok(shippers);
    }

    [HttpGet("/shipment/{shipperId:int}")]
    public async Task<ActionResult> Get(int shipperId)
    {
        var shipper = await _mediator.Send(new GetShipperShipmentDetailsQuery(shipperId));
        return shipper is null ? NotFound() : Ok(shipper);
    }

    [HttpGet("/quotes/random")]
    public async Task<ActionResult> GetRandomQuote()
    {
        var quote = await _mediator.Send(new GetRandomQuoteQuery());
        return quote is null ? NotFound() : Ok(quote);
    }

    [HttpGet("/quotes/{author}")]
    public async Task<ActionResult> GetGroupedQuotesByAuthor(string author, int limit = 30)
    {
        var quotes = await _mediator.Send(new GetGroupedQuotesByAuthorQuery(author, limit));
        return quotes is null ? NotFound() : Ok(quotes);
    }
}
