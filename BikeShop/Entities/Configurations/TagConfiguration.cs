using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> tag)
    {
        tag.HasKey(t => t.Id);
        tag.Property(t => t.Name).IsRequired().HasMaxLength(15);
    }
}