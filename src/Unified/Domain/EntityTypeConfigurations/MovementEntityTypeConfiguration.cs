namespace LasMarias.Domain.EntityTypeConfigurations;


public class MovementEntityTypeConfiguration : IEntityTypeConfiguration<Movement>
{
    public void Configure(EntityTypeBuilder<Movement> builder)
    {
        builder.HasKey(x => x.MovementId);
        builder
            .HasOne(x => x.Vendor)
            .WithMany(x => x.Movements)
            .HasForeignKey(x => x.VendorId);
        builder
            .HasMany(x => x.ProductMovements)
            .WithOne(x => x.Movement);
    }
}