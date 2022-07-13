namespace LasMarias.Profile.Domain.EntityTypeConfigurations;

public class WorkerEntityTypeConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasKey(x => x.WorkerId);
        // TODO: check if this is possible in real live
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Worker!);
    }
}