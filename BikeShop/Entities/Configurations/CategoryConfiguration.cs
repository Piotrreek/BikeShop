using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> category)
    {
        category.HasKey(c => c.Id);
        category.Property(c => c.Name).IsRequired().HasMaxLength(15);
    }
}