namespace LasMarias.Domain.EntityTypeConfigurations;

public class ApplicationUserEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.Country)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CountryId);
        builder
            .HasMany(x => x.ReferredUsers)
            .WithOne(x => x.ReferralUser)
            .HasForeignKey(x => x.ReferralUserId);
        builder
            .HasMany(x => x.Benefits)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne(x => x.Employee)
            .WithOne(x => x.User)
            .HasForeignKey<Employee>(x => x.EmployeeId);
    }
}