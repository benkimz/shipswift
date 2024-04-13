using System.ComponentModel.DataAnnotations;

namespace ShipSwift.CoreBusiness.Models;

public partial class Shipper
{
    public int ShipperId { get; set; }
    [MaxLength(100)]
    public required string ShipperName { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
