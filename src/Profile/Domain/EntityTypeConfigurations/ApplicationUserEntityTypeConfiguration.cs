namespace LasMarias.Profile.Domain.EntityTypeConfigurations;

public class ApplicationUserEntityTypeConfiguration: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // todo: check why EF is asking for this
        builder
            .HasKey(u => u.Id);
        
        builder
            .HasOne(ch => ch.ReferralUser)
            .WithMany(c => c.ReferredUsers)
            .HasForeignKey(ch => ch.ReferralUserId);
    }
}
