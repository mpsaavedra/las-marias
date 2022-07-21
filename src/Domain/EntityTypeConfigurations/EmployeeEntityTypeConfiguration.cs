namespace LasMarias.Domain.EntityTypeConfigurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.EmployeeId);
        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Employee)
            .HasForeignKey<ApplicationUser>(x => x.EmployeeId);
    }
}