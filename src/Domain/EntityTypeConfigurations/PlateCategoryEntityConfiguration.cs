namespace LasMarias.Domain.EntityTypeConfigurations;

public class PlateCategoryEntityConfiguration : IEntityTypeConfiguration<PlateCategory>
{
    public void Configure(EntityTypeBuilder<PlateCategory> builder)
    {
        builder.HasKey(x => x.PlateCategoryId);
        builder
            .HasOne(x => x.Plate)
            .WithMany(x => x.PlateCategories)
            .HasForeignKey(x => x.PlateId);
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.PlateCategories)
            .HasForeignKey(x => x.CategoryId);
    }
}