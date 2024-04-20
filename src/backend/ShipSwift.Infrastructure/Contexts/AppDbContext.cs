using Microsoft.EntityFrameworkCore;
using ShipSwift.CoreBusiness.Models;

namespace ShipSwift.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Shipment> Shipments { get; set; }

    public DbSet<Carrier> Carriers { get; set; }
    public DbSet<ShipmentRate> ShipmentRates { get; set; }
}
