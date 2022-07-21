namespace LasMarias.Domain.EntityTypeConfigurations;

public class MeasureUnitEntityTypeConfiguration : IEntityTypeConfiguration<MeasureUnit>
{
    public void Configure(EntityTypeBuilder<MeasureUnit> builder)
    {
        builder.HasKey(x => x.MeasureUnitId);
        builder
            .HasMany(x => x.Products)
            .WithOne(x => x.MeasureUnit);
    }
}