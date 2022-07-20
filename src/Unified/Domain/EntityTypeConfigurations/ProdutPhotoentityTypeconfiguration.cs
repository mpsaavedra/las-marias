namespace LasMarias.Domain.EntityTypeConfigurations;

public class ProductPhotoEntityTypeConfiguration : IEntityTypeConfiguration<ProductPhoto>
{
    public void Configure(EntityTypeBuilder<ProductPhoto> builder)
    {
        builder.HasKey(x => x.ProductPhotoId);
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.ProductPhotos)
            .HasForeignKey(x => x.ProductPhotoId);
    }
}