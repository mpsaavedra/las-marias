namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.BrandId);
        builder
            .HasMany(x => x.ProductBrands)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId);
        builder
            .HasMany(x => x.VendorBrands)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId);
    }
}