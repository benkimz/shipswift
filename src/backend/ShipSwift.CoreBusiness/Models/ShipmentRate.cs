using System.ComponentModel.DataAnnotations;

namespace ShipSwift.CoreBusiness.Models;

public class ShipmentRate
{
    public int ShipmentRateId { get; set; }
    [MaxLength(10)]
    public string ShipmentRateClass { get; set; } = null!;
    [MaxLength(25)]
    public string ShipmentRateDescription { get; set; } = null!;
}
