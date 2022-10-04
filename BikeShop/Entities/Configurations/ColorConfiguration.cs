using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> color)
    {
        color.HasKey(c => c.Id);
        color.Property(c => c.Name).IsRequired().HasMaxLength(10);
        color.HasData(SeedColors());
    }

    private List<Color> SeedColors()
    {
        return new List<Color>
        {
            new Color()
            {
                Id = 2,
                Name = "Blue",
            },
            new Color()
            {
                Id = 3,
                Name = "Red"
            },
            new Color()
            {
                Id = 4,
                Name = "White"
            }
        };
    }
}