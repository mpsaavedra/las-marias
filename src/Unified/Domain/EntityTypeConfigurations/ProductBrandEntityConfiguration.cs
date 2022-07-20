namespace LasMarias.Domain.EntityTypeConfigurations;

public class ProductBrandEntityTypeConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.HasKey(x => x.ProductBrandId);
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.ProductBrands)
            .HasForeignKey(x => x.BrandId);
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductBrands)
            .HasForeignKey(x => x.ProductId);
    }
}