using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;

namespace Orun.Extensions;

/// <summary>
/// Service Collection extensions
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add app configuration 
    /// </summary>
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
    {
        
        services.AddSingleton<IConfiguration>(config);
        return services;
    }


    /// <summary>
    /// Adds Heaclthcheck and serilog loggin into the service collections middlewares
    /// </summary>
    public static IServiceCollection AddHealthCheckAndSerilog(this IServiceCollection services,
        IConfiguration configuration)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            
            services.AddSerilogLogging();
            
            services
                .AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());
        }
        catch (Exception ex)
        {
            ConsoleColor.Red.WriteLine(ex.FullMessage());
        }

        return services;
    }
    
    /// <summary>
    /// Adds Serilog logger to the services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSerilogLogging(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();

        try
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(configuration["Logging:LoggingFile"])
                .CreateLogger();

            services.AddLogging(logBuilder => logBuilder.AddSerilog());
        }
        catch (Exception ex)
        {
            // do nothing if we don't load the app settings section logger won't work
            ConsoleColor.Red.WriteLine($"Settings could not be loaded: {ex.Message}");
        }

        return services;
    }

}