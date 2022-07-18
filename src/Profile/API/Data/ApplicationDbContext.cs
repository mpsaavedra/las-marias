namespace LasMarias.Profile.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    {
    }

    public virtual DbSet<Benefit> Benefits => Set<Benefit>();

    public virtual DbSet<Country> Countries => Set<Country>();

    public virtual DbSet<Employee> Employees => Set<Employee>();

    public virtual DbSet<User> Users => Set<User>();

    public virtual DbSet<UserBenefit> UserBenefits => Set<UserBenefit>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BenefitEntityTypeConfiguration());
        builder.ApplyConfiguration(new CountryEntityTypeConfiguration());
        builder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
        builder.ApplyConfiguration(new UserEntityTypeConfiguration());
        builder.ApplyConfiguration(new UserBenefitEntityTypeConfiguration());
    }
}