namespace LasMarias.Domain.EntityTypeConfigurations;

public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.CountryId);
        builder
            .HasMany(x => x.Users)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);
    }
}