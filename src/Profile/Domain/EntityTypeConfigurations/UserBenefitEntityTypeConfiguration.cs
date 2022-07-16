namespace LasMarias.Profile.Domain.EntityTypeConfigurations;

public class UserBenefitEntityTypeConfiguration : IEntityTypeConfiguration<UserBenefit>
{
    public void Configure(EntityTypeBuilder<UserBenefit> builder)
    {
        builder.HasKey(x => x.UserBenefitId);
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Benefits)
            .HasForeignKey(x => x.BenefitId);
        builder
            .HasOne(x => x.Benefit)
            .WithMany(x => x.UserBenefits)
            .HasForeignKey(x => x.BenefitId);
    }
}