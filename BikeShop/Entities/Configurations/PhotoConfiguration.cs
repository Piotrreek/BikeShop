using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> photo)
    {
        photo.HasKey(p => p.Id);
        photo.Property(p => p.PhotoPath).IsRequired();
    }
}