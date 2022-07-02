namespace LasMarias.WareHouse.Domain.EntityTypeConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LasMarias.WareHouse.Domain.Models;

public class VendorBrandEntityTypeConfiguration : IEntityTypeConfiguration<VendorBrand>
{
    public void Configure(EntityTypeBuilder<VendorBrand> builder)
    {
        builder.HasKey(x => x.VendorBrandId);
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.VendorBrands)
            .HasForeignKey(x => x.BrandId);
        builder
            .HasOne(x => x.Vendor)
            .WithMany(x => x.VendorBrands)
            .HasForeignKey(x => x.VendorBrandId);
    }
}