using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder
    .AddCustomSerilog()
    .AddCustomDatabase()
    .AddCustomHealthChecks();

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

app.MapControllers();

app
    .ApplyDatabaseMigration()
    .UseGraphQL();

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
