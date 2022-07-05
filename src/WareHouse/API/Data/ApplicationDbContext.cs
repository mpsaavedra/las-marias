namespace LasMarias.WareHouse.Data;

using Microsoft.EntityFrameworkCore;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.EntityTypeConfigurations;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Attribute> Attributes => Set<Attribute>();

    public virtual DbSet<AttributeName> AttributeNames => Set<AttributeName>();

    public virtual DbSet<Brand> Brands => Set<Brand>();

    public virtual DbSet<Category> Categories => Set<Category>();

    public virtual DbSet<Movement> Movements => Set<Movement>();

    public virtual DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();

    public virtual DbSet<Product> Products => Set<Product>();

    public virtual DbSet<ProductMovement> ProductMovements => Set<ProductMovement>();

    public virtual DbSet<ProductPhoto> ProductPhotos => Set<ProductPhoto>();

    public virtual DbSet<Vendor> Vendors => Set<Vendor>();

    public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration( new AttributeEntityTypeConfiguration());
        builder.ApplyConfiguration( new AttributeNameEntityTypeConfiguration());
        builder.ApplyConfiguration( new CategoryEntityTypeConfiguration());
        builder.ApplyConfiguration( new MovementEntityTypeConfiguration());
        builder.ApplyConfiguration( new PriceHistoryEntityTypeConfiguration());
        builder.ApplyConfiguration( new ProductEntityTypeConfiguration());
        builder.ApplyConfiguration( new ProductMovementEntityTypeConfiguration());
        builder.ApplyConfiguration( new ProductPhotoEntityTypeConfiguration());
        builder.ApplyConfiguration( new VendorEntityTypeConfiguration());
        builder.ApplyConfiguration( new MeasureUnitEntityTypeConfiguration());
    }
}