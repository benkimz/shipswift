namespace ShipSwift.Api;

public class ShipmentDTO
{
    public int ShipmentId { get; set; }
    public string ShipmentDescription { get; set; } = string.Empty;
    public decimal ShipmentWeight { get; set; }
    public CarrierDTO? Carrier { get; set; }
    public ShipmentRateDTO? ShipmentRate { get; set; }
    public ShipperDTO? Shipper { get; set; }
}
