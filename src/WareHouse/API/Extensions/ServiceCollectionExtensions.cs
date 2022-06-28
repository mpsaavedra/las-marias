using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Extensions;
using Serilog;
using Orun.Extensions;

namespace LasMarias.WareHouse.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
    {
        
        services.AddSingleton<IConfiguration>(config);
        return services;
    }


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
            
            services.AddLogging(logBuilder => logBuilder.AddSerilog());
            
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