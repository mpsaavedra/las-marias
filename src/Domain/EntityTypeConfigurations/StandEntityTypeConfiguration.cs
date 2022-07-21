namespace LasMarias.Domain.EntityTypeConfigurations;


public class StandEntityTypeConfiguration : IEntityTypeConfiguration<Stand>
{
    public void Configure(EntityTypeBuilder<Stand> builder)
    {
        builder.HasKey(x => x.StandId);
        builder
            .HasMany(x => x.Tables)
            .WithOne(x => x.Stand!)
            .HasForeignKey(x => x.StandId);
        builder
            .HasMany(x => x.Seats)
            .WithOne(x => x.Stand!)
            .HasForeignKey(x => x.StandId);
    }
}