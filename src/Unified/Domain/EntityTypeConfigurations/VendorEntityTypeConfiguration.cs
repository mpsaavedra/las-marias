namespace LasMarias.Domain.EntityTypeConfigurations;

public class VendorEntityTypeConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.HasKey(x => x.VendorId);
        builder
            .HasMany(x => x.Movements)
            .WithOne(x => x.Vendor);
        builder
            .HasMany(x => x.VendorBrands)
            .WithOne(x => x.Vendor)
            .HasForeignKey(x => x.VendorId);
    }
}