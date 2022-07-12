namespace LasMarias.PoS.Domain.EntityTypeConfigurations;

public class PlatePhotoEntityConfiguration: IEntityTypeConfiguration<PlatePhoto>
{
    public void Configure(EntityTypeBuilder<PlatePhoto> builder)
    {
        builder.HasKey(x => x.PlatePhotoId);
        builder
            .HasOne(x => x.Plate)
            .WithMany(x => x.PlatePhotos)
            .HasForeignKey(x => x.PlateId);
    }
}