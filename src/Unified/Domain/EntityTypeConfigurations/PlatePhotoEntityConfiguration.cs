namespace LasMarias.Domain.EntityTypeConfigurations;

public class PlatePhotoEntityTypeConfiguration : IEntityTypeConfiguration<Models.PlatePhoto>
{
    public void Configure(EntityTypeBuilder<Models.PlatePhoto> builder)
    {
        builder.HasKey(x => x.PlatePhotoId);
        builder
            .HasOne(x => x.Plate)
            .WithMany(x => x.PlatePhotos)
            .HasForeignKey(x => x.PlateId);
    }
}