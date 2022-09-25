using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Type = BikeShop.Entities.Enums.Type;

namespace BikeShop.Entities.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.HasKey(c => c.Id);
        category.Property(c => c.Name).IsRequired().HasMaxLength(15);
        category.HasData(SeedCategories());
    }

    private List<Category> SeedCategories()
    {
        var categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Type = Type.Bike,
                Name = "Mountain Bike"
            },
            new Category
            {
                Id = 2,
                Type = Type.Bike,
                Name = "Road Bike"
            },
            new Category
            {
                Id = 3,
                Type = Type.Bike,
                Name = "BMX Bike"
            },
            new Category
            {
                Id = 4,
                Type = Type.Bike,
                Name = "Gravel Bike"
            },
            new Category
            {
                Id = 5,
                Type = Type.Bike,
                Name = "Electric Bike"
            }
        };

        return categories;
    }
    
}