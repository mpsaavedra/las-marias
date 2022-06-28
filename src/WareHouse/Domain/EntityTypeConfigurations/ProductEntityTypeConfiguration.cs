namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder
            .HasMany(x => x.ProductPhotos)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
        builder
            .HasMany( x => x.Categories)
            .WithMany( x => x.Products);
        builder
            .HasMany(x => x.Attributes)
            .WithMany(x => x.Products);
        builder
            .HasMany(x => x.PriceHistories)
            .WithOne(x => x.Product);
        builder
            .HasOne(x => x.MeasureUnit)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.MeasureUnitId);
    }
}