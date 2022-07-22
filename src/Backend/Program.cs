var builder = WebApplication.CreateBuilder(args);
const string APP_NAME = "Las Marias";
var IS_DEVELOPMENT = builder.Environment.IsDevelopment();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder
    .AddCustomSerilog(APP_NAME)
    .AddCustomDatabase<ApplicationDbContext>(
        connectionString, IS_DEVELOPMENT
    )
    .AddCustomHealthChecks()
    .AddCustomGraphQL(
        IS_DEVELOPMENT,
        qry => qry
            .AddType<ApplicationUserQueries>()
            .AddType<AttributeQueries>()
            .AddType<AttributeNameQueries>()
            .AddType<BenefitQueries>()
            .AddType<BrandQueries>()
            .AddType<CategoryQueries>()
            .AddType<CountryQueries>()
            .AddType<EmployeeQueries>()
            .AddType<MeasureUnitQueries>()
            .AddType<MenuQueries>()
            .AddType<MenuPlateQueries>()
            .AddType<MovementQueries>()
            .AddType<PlateQueries>()
            .AddType<PlatePhotoQueries>()
            .AddType<PlateCategoryQueries>()
            .AddType<PriceHistoryQueries>()
            .AddType<ProductQueries>()
            .AddType<ProductBrandQueries>()
            .AddType<ProductMovementQueries>()
            .AddType<ProductPhotoQueries>()
            .AddType<SeatQueries>()
            .AddType<StandQueries>()
            .AddType<TableQueries>()
            .AddType<UserBenefitQueries>()
            .AddType<VendorQueries>()
            .AddType<VendorBrandQueries>()
            .AddType<VouceQueries>(),
        mts => mts
            .AddType<ApplicationUserMutations>()
            .AddType<AttributeMutations>()
            .AddType<AttributeNameMutations>()
            .AddType<BenefitMutations>()
            .AddType<BrandMutations>()
            .AddType<CategoryMutations>()
            .AddType<CountryMutations>()
            .AddType<EmployeeMutations>()
            .AddType<MeasureUnitMutations>()
            .AddType<MenuMutations>()
            .AddType<MenuPlateMutations>()
            .AddType<MovementMutations>()
            .AddType<PlateMutations>()
            .AddType<PlatePhotoMutations>()
            .AddType<PlateCategoryMutations>()
            .AddType<PriceHistoryMutations>()
            .AddType<ProductMutations>()
            .AddType<ProductBrandMutations>()
            .AddType<ProductMovementMutations>()
            .AddType<ProductPhotoMutations>()
            .AddType<SeatMutations>()
            .AddType<StandMutations>()
            .AddType<TableMutations>()
            .AddType<UserBenefitMutations>()
            .AddType<VendorMutations>()
            .AddType<VendorBrandMutations>()
            .AddType<VouceMutations>()
    );

var pluginsDir = IS_DEVELOPMENT
                ? System.IO.Path.Combine(System.Environment.CurrentDirectory, "..", "plugins")
                : System.IO.Path.Combine(System.Environment.CurrentDirectory, "plugins");

// add plugins and load business logic from them
builder.AddPluginsServices(pluginsDir);

// register Repositories
builder.Services
    .AddScoped<IApplicationUserRepository, ApplicationUserRepository>()
    .AddScoped<IAttributeNameRepository, AttributeNameRepository>()
    .AddScoped<IAttributeRepository, AttributeRepository>()
    .AddScoped<IBenefitRepository, BenefitRepository>()
    .AddScoped<IBrandRepository, BrandRepository>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<ICountryRepository, CountryRepository>()
    .AddScoped<IEmployeeRepository, EmployeeRepository>()
    .AddScoped<IMenuRepository, MenuRepository>()
    .AddScoped<IMenuPlateRepository, MenuPlateRepository>()
    .AddScoped<IMeasureUnitRepository, MeasureUnitRepository>()
    .AddScoped<IMovementRepository, MovementRepository>()
    .AddScoped<IPlateRepository, PlateRepository>()
    .AddScoped<IPlateCategoryRepository, PlateCategoryRepository>()
    .AddScoped<IPlatePhotoRepository, PlatePhotoRepository>()
    .AddScoped<IPlateCategoryRepository, PlateCategoryRepository>()
    .AddScoped<IPlateProductRepository, PlateProductRepository>()
    .AddScoped<IPriceHistoryRepository, PriceHistoryRepository>()
    .AddScoped<IProductBrandRepository, ProductBrandRepository>()
    .AddScoped<IProductMovementRepository, ProductMovementRepository>()
    .AddScoped<IProductPhotoRepository, ProductPhotoRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<ISeatRepository, SeatRepository>()
    .AddScoped<IStandRepository, StandRepository>()
    .AddScoped<ITableRepository, TableRepository>()
    .AddScoped<IUserBenefitRepository, UserBenefitRepository>()
    .AddScoped<IVendorBrandRepository, VendorBrandRepository>()
    .AddScoped<IVendorRepository, VendorRepository>()
    .AddScoped<IVouceRepository, VouceRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app
    .ApplyDatabaseMigration<ApplicationDbContext>()
    .ConfigurePlugins()
    .UseGraphQL();

app.Run();
