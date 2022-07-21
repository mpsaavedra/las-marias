namespace LasMarias.Domain.EntityTypeConfigurations;


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