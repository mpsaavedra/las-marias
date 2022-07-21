namespace LasMarias.Domain.EntityTypeConfigurations;

public class AttributeEntityTypeConfiguration : IEntityTypeConfiguration<Models.Attribute>
{
    public void Configure(EntityTypeBuilder<Models.Attribute> builder)
    {
        builder.HasKey(x => x.AttributeId);

        builder
            .HasOne(x => x.AttributeName)
            .WithMany(x => x.Attributes);

        builder
            .HasMany(x => x.Products)
            .WithMany(x => x.Attributes);
    }
}