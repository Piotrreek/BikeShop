using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeShop.Entities.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.Property(p => p.Name).IsRequired();
        product.Property(p => p.Price).IsRequired().HasPrecision(18, 2);
        product.Property(p => p.Description).IsRequired();
        product.Property(p => p.InStock).IsRequired();
        product.Property(p => p.AvailableQuantity).IsRequired();
        product.Property(p => p.Brand).IsRequired();
        product.Property(p => p.NumberOfPurchases).HasDefaultValue(0);
        product.Property(p => p.CreatedTime).HasDefaultValueSql("getutcdate()");
        product.Property(p => p.UpdatedTime).HasDefaultValueSql("getutcdate()");
        product.HasKey(p => p.Id);

        product.HasMany(p => p.Photos)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId);

        product.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        product.HasMany(p => p.Tags)
            .WithMany(p => p.Products)
            .UsingEntity(j => j.ToTable("ProductTag"));

        product.HasOne(p => p.Color)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.ColorId);
    }
}