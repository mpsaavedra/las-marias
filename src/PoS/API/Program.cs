using LasMarias.PoS.Extensions;

var builder = WebApplication.CreateBuilder(args);

const string APP_NAME = "Point of Sale";
var IS_DEVELOPMENT = builder.Environment.IsDevelopment();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder
    .AddCustomSerilog(APP_NAME)
    .AddCustomDatabase<ApplicationDbContext>(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        IS_DEVELOPMENT
    )
    .AddCustomHealthChecks()
    .AddCustomGraphQL(
        IS_DEVELOPMENT,
        qry => qry
            .AddType<CategoryQuery>()
            .AddType<MenuQuery>()
            .AddType<MenuPlateQuery>()
            .AddType<PlatePhotoQuery>()
            .AddType<PlateProductQuery>()
            .AddType<PlateQuery>()
            .AddType<SeatQuery>()
            .AddType<StandQuery>()
            .AddType<TableQuery>()
    );

builder.Services
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<IMenuPlateRepository, MenuPlateRepository>()
    .AddScoped<IMenuRepository, MenuRepository>()
    .AddScoped<IPlatePhotoRepository, PlatePhotoRepository>()
    .AddScoped<IPlateProductRepository, PlateProductRepository>()
    .AddScoped<IPlateRepository, PlateRepository>()
    .AddScoped<ISeatRepository, SeatRepository>()
    .AddScoped<IStandRepository, StandRepository>()
    .AddScoped<ITableRepository, TableRepository>()
    ;

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// app.UseAuthentication();
app
    .ApplyDatabaseMigration<ApplicationDbContext>()
    .UseGraphQL();

app.UseAuthorization();

app.MapControllers();



app.Run();
