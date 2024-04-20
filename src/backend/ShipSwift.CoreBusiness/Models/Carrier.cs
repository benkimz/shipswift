using System.ComponentModel.DataAnnotations;

namespace ShipSwift.CoreBusiness.Models;

public class Carrier
{
    public int CarrierId { get; set; }
    [MaxLength(100)]
    public required string CarrierName { get; set; }
    [MaxLength(25)]
    public required string CarrierMode { get; set; }
}
