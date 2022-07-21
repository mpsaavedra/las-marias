using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;

namespace LasMarias.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {

    }

    public virtual DbSet<LasMarias.Domain.Models.Attribute> Attributes => Set<LasMarias.Domain.Models.Attribute>();

    public virtual DbSet<AttributeName> AttributeNames => Set<AttributeName>();

    public virtual DbSet<Benefit> Benefits => Set<Benefit>();

    public virtual DbSet<Brand> Brands => Set<Brand>();

    public virtual DbSet<Category> Categories => Set<Category>();

    public virtual DbSet<Country> Countries => Set<Country>();

    public virtual DbSet<Employee> Employees => Set<Employee>();

    public virtual DbSet<MeasureUnit> MeasureUnits => Set<MeasureUnit>();

    public virtual DbSet<Menu> Menus => Set<Menu>();

    public virtual DbSet<MenuPlate> MenuPlates => Set<MenuPlate>();

    public virtual DbSet<Movement> Movements => Set<Movement>();

    public virtual DbSet<Plate> Plates => Set<Plate>();

    public virtual DbSet<PlateCategory> PlateCategories => Set<PlateCategory>();

    public virtual DbSet<PlatePhoto> PlatePhotos => Set<PlatePhoto>();

    public virtual DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();

    public virtual DbSet<Product> Products => Set<Product>();

    public virtual DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

    public virtual DbSet<ProductMovement> ProductMovements => Set<ProductMovement>();

    public virtual DbSet<ProductPhoto> ProductPhotos => Set<ProductPhoto>();

    public virtual DbSet<Seat> Seats => Set<Seat>();

    public virtual DbSet<Stand> Stands => Set<Stand>();

    public virtual DbSet<Table> Tables => Set<Table>();

    public virtual DbSet<Vendor> Vendors => Set<Vendor>();

    public virtual DbSet<Vouce> Vouces => Set<Vouce>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityTypeConfiguration());
        builder.ApplyConfiguration(new AttributeEntityTypeConfiguration());
        builder.ApplyConfiguration(new AttributeNameEntityTypeConfiguration());
        builder.ApplyConfiguration(new BenefitEntityTypeConfiguration());
        builder.ApplyConfiguration(new BrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        builder.ApplyConfiguration(new CountryEntityTypeConfiguration());
        builder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
        builder.ApplyConfiguration(new MeasureUnitEntityTypeConfiguration());
        builder.ApplyConfiguration(new MovementEntityTypeConfiguration());
        builder.ApplyConfiguration(new PriceHistoryEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductMovementEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductPhotoEntityTypeConfiguration());
        builder.ApplyConfiguration(new VendorBrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new VendorEntityTypeConfiguration());
        builder.ApplyConfiguration(new VouceEntityTypeConfiguration());
    }
}
