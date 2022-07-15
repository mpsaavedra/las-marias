using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Extensions;
using Serilog;
using Orun.Extensions;

var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();
const string APP_NAME = "WareHouse";

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder
    .AddCustomSerilog(APP_NAME)
    .AddCustomDatabase<ApplicationDbContext>(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        isDevelopment
    )
    .AddCustomHealthChecks();

if(isDevelopment)
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// add custom services
builder.Services
    .AddGraphQlConfiguration(isDevelopment)
    .AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();

app.MapControllers();

app
    .ApplyDatabaseMigration<ApplicationDbContext>()
    .UseGraphQL()
    .UsePlugIns();

// this seeding is only for the template to bootstrap the DB and users.
    // in production you will likely want a different approach.
if (args.Contains("/seed"))
{
    Log.Information("Seeding database...");
    SeedData.EnsureSeedData(app);
    Log.Information("Done seeding database. Exiting.");
    return;
}

app.Run();
