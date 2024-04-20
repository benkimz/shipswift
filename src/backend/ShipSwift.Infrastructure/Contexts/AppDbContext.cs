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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.ToTable("SHIPPER");
            entity.Property(e => e.ShipperId).HasColumnName("shipper_id");
            entity.Property(e => e.ShipperName).HasColumnName("shipper_name");
            entity.HasMany(e => e.Shipments).WithOne().HasForeignKey("shipper_id");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.ToTable("SHIPMENT");
            entity.Property(e => e.ShipmentId).HasColumnName("shipment_id");
            entity.Property(e => e.ShipmentDescription).HasColumnName("shipment_description");
            entity.Property(e => e.ShipmentWeight).HasColumnName("shipment_weight");
            entity.HasOne(e => e.Carrier).WithMany().HasForeignKey("carrier_id");
            entity.HasOne(e => e.ShipmentRate).WithMany().HasForeignKey("shipment_rate_id");
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.ToTable("CARRIER");
            entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
            entity.Property(e => e.CarrierName).HasColumnName("carrier_name");
            entity.Property(e => e.CarrierMode).HasColumnName("carrier_mode");
        });

        modelBuilder.Entity<ShipmentRate>(entity =>
        {
            entity.ToTable("SHIPMENT_RATE");
            entity.Property(e => e.ShipmentRateId).HasColumnName("shipment_rate_id");
            entity.Property(e => e.ShipmentRateClass).HasColumnName("shipment_rate_class");
            entity.Property(e => e.ShipmentRateDescription).HasColumnName("shipment_rate_description");
        });
    }

}
