using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipSwift.CoreBusiness.Models;

public class Shipment
{
    public int ShipmentId { get; set; }
    [MaxLength(100)]
    public required string ShipmentDescription { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal ShipmentWeight { get; set; }
    public required virtual Carrier Carrier { get; set; }
    public required virtual ShipmentRate ShipmentRate { get; set; }
}