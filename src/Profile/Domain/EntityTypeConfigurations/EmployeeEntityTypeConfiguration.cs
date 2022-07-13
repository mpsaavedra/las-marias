namespace LasMarias.Profile.Domain.EntityTypeConfigurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.EmployeeId);
        // TODO: check if this is possible in real live
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Employee!);
    }
}