namespace LasMarias.Domain.EntityTypeConfigurations;

public class PlateProductEntityTypeConfiguration : IEntityTypeConfiguration<PlateProduct>
{
    public void Configure(EntityTypeBuilder<PlateProduct> builder)
    {
        builder.HasKey(x => x.PlateProductId);
        builder
            .HasOne(x => x.Plate)
            .WithMany(x => x.PlateProducts)
            .HasForeignKey(x => x.PlateId);
        // builder
        //     .HasOne(x => x.Product)
        //     .WithMany(x => x.);
    }
}