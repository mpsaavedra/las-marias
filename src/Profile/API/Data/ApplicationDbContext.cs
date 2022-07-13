using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using LasMarias.Profile.Domain.Models;
using LasMarias.Profile.Domain.EntityTypeConfigurations;

namespace LasMarias.Profile.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    public virtual DbSet<Benefit> Benefits => Set<Benefit>();

    public virtual DbSet<Country> Countries => Set<Country>();

    public virtual DbSet<UserBenefit> UserBenefits => Set<UserBenefit>();

    public virtual DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ApplicationUserEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BenefitEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserBenefitEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
    }
}
