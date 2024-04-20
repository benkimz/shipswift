using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShipSwift.CoreBusiness;

namespace ShipSwift.Api;

[ApiController]
[Route("api/shippers")]
[Consumes("application/json")]
[Produces("application/json")]
public class ShippersController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShippersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/all")]
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
}
