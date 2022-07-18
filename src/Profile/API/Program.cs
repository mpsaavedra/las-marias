var builder = WebApplication.CreateBuilder(args);

const string APP_NAME = "Profile";
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
            .AddType<BenefitQueries>()
            .AddType<CountryQueries>()
            .AddType<EmployeeQueries>()
            .AddType<UserQueries>()
            .AddType<UserBenefitQueries>(),
        mut => mut
            .AddType<BenefitMutations>()
            .AddType<CountryMutations>()
            .AddType<EmployeeMutations>()
            .AddType<UserMutations>()
    );

builder.Services
    .AddScoped<IBenefitRepository, BenefitRepository>()
    .AddScoped<ICountryRepository, CountryRepository>()
    .AddScoped<IEmployeeRepository, EmployeeRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUserBenefitRepository, UserBenefitRepository>();


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
app.UseGraphQL();

app.UseAuthorization();

app.MapControllers();

app
    .ApplyDatabaseMigration<ApplicationDbContext>()
    .ConfigurePlugins();

app.Run();
