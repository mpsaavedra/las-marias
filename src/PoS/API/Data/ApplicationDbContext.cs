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

    public virtual DbSet<Category> Categories => Set<Category>();

    public virtual DbSet<MenuPlate> MenuPlates => Set<MenuPlate>();

    public virtual DbSet<Menu> Menus => Set<Menu>();

    public virtual DbSet<PlatePhoto> PlatePhotos => Set<PlatePhoto>();

    public virtual DbSet<PlateProduct> PlateProducts => Set<PlateProduct>();

    public virtual DbSet<Plate> Plates => Set<Plate>();

    public virtual DbSet<Seat> Seats => Set<Seat>();

    public virtual DbSet<Stand> Stands => Set<Stand>();

    public virtual DbSet<Table> Tables => Set<Table>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryEntityTypeCofiguration());
        builder.ApplyConfiguration(new MenuPlateEntityTypeConfiguration());
        builder.ApplyConfiguration(new MenuEntityTypeCofiguration());
        builder.ApplyConfiguration(new PlatePhotoEntityTypeConfiguration());
        builder.ApplyConfiguration(new PlateProductEntityTypeConfiguration());
        builder.ApplyConfiguration(new PlateEntityTypeConfiguration());
        builder.ApplyConfiguration(new SeatEntityTypeConfiguration());
        builder.ApplyConfiguration(new StandEntityTypeConfiguration());
        builder.ApplyConfiguration(new TableEntityTypeConfiguration());
    }
}