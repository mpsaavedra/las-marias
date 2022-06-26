namespace LasMarias.PoS.Data;

using Microsoft.EntityFrameworkCore;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.EntityTypeConfigurations;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Seat> Seats => Set<Seat>();

    public virtual DbSet<Stand> Stands => Set<Stand>();

    public virtual DbSet<Table> Tables => Set<Table>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration( new SeatEntityTypeConfiguration());
        builder.ApplyConfiguration( new StandEntityTypeConfiguration());
        builder.ApplyConfiguration( new TableEntityTypeConfiguration());
    }
}