namespace ShipSwift.Api;

public class ShipperDTO
{
    public int ShipperId { get; set; }
    public string ShipperName { get; set; } = string.Empty;
    public List<ShipmentDTO> Shipments { get; set; } = new List<ShipmentDTO>();
}
