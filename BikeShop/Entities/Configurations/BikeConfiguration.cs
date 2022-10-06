using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class BikeConfiguration : IEntityTypeConfiguration<Bike>
{
    public void Configure(EntityTypeBuilder<Bike> mountainBike)
    {
        mountainBike.ToTable("Bikes");
        mountainBike.Property(mb => mb.UserGender).IsRequired();
        mountainBike.Property(mb => mb.Size).IsRequired();
        mountainBike.Property(mb => mb.ProductionYear).IsRequired().HasMaxLength(4);
    }
}