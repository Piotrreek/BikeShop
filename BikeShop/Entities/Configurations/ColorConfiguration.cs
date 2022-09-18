using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> color)
    {
        color.HasKey(c => c.Id);
        color.Property(c => c.Name).IsRequired().HasMaxLength(10);
    }
}