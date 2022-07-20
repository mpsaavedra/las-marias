using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string APP_NAME = "Las Marias";
var IS_DEVELOPMENT = builder.Environment.IsDevelopment();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder
    .AddCustomSerilog(APP_NAME)
    .AddCustomDatabase<ApplicationDbContext>(
        connectionString, IS_DEVELOPMENT
    )
    .AddCustomHealthChecks()
    .AddCustomGraphQL(
        IS_DEVELOPMENT,
        qry => qry
            .AddType<AttributeNameQueries>()
            .AddType<AttributeQueries>()
            .AddType<BrandQueries>()
            .AddType<CategoryQueries>()
            .AddType<MeasureUnitQueries>()
            .AddType<MovementQueries>()
            .AddType<PriceHistoryQueries>()
            .AddType<ProductPhotoQueries>()
            .AddType<ProductBrandQueries>()
            .AddType<ProductQueries>()
            .AddType<VendorBrandQueries>()
            .AddType<VendorQueries>()
            .AddType<VouceQueries>()
    );

if (IS_DEVELOPMENT)
{
    builder.AddPluginsServices(System.IO.Path.Combine(System.Environment.CurrentDirectory, "..", "plugins"));
}
else
{
    // in production we should red configuration files first then check if a plugins directory
    // exists and try load plugins from there.
    builder.AddPluginsServices(System.IO.Path.Combine(System.Environment.CurrentDirectory, "plugins"));
}

builder.Services
    .AddScoped<IAttributeNameRepository, AttributeNameRepository>()
    .AddScoped<IAttributeRepository, AttributeRepository>()
    .AddScoped<IBrandRepository, BrandRepository>()
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<IMeasureUnitRepository, MeasureUnitRepository>()
    .AddScoped<IMovementRepository, MovementRepository>()
    .AddScoped<IPriceHistoryRepository, PriceHistoryRepository>()
    .AddScoped<IProductBrandRepository, ProductBrandRepository>()
    .AddScoped<IProductPhotoRepository, ProductPhotoRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IVendorBrandRepository, VendorBrandRepository>()
    .AddScoped<IVendorRepository, VendorRepository>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app
    .ApplyDatabaseMigration<ApplicationDbContext>()
    .ConfigurePlugins();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;

app.Run();
