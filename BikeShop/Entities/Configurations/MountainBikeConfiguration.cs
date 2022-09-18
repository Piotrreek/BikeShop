using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class MountainBikeConfiguration : IEntityTypeConfiguration<MountainBike>
{
    public void Configure(EntityTypeBuilder<MountainBike> mountainBike)
    {
        mountainBike.ToTable("MountainBikes");
        mountainBike.Property(mb => mb.Size).IsRequired();
        mountainBike.Property(mb => mb.ProductionYear).IsRequired().HasMaxLength(4);
    }
}