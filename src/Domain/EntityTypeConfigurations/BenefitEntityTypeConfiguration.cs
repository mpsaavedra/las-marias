namespace LasMarias.Domain.EntityTypeConfigurations;

public class BenefitEntityTypeConfiguration : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.HasKey(x => x.BenefitId);
        builder
            .HasMany(x => x.UserBenefits)
            .WithOne(x => x.Benefit)
            .HasForeignKey(x => x.BenefitId);
    }
}