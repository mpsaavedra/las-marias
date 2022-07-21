namespace LasMarias.Domain.EntityTypeConfigurations;

public class PlateEntityTypeConfiguration : IEntityTypeConfiguration<Plate>
{
    public void Configure(EntityTypeBuilder<Plate> builder)
    {
        builder.HasKey(x => x.PlateId);
        builder
            .HasMany(x => x.PlateProducts)
            .WithOne(x => x.Plate)
            .HasForeignKey(x => x.PlateId);
        builder
            .HasMany(x => x.MenuPlates)
            .WithOne(x => x.Plate)
            .HasForeignKey(x => x.PlateId);
        builder
            .HasMany(x => x.PlateCategories)
            .WithOne(x => x.Plate)
            .HasForeignKey(x => x.PlateId);
        builder
            .HasMany(x => x.PlatePhotos)
            .WithOne(x => x.Plate)
            .HasForeignKey(x => x.PlateId);
    }
}