namespace LasMarias.Profile.Domain.EntityTypeConfigurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.EmployeeId);
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Employee)
            .HasForeignKey<User>(x => x.EmployeeId);
    }
}