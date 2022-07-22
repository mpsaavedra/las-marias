namespace Orun.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Polly;
using Serilog;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

/// <summary>
/// Program extensions
/// </summary>
public static class ProgramExtensions
{

    /// <summary>
    /// adds health checks endpoints
    /// </summary>
    public static WebApplicationBuilder AddCustomHealthChecks(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy());
        return builder;
    }

    /// <summary>
    /// apply database migrations, it includes a Retry Policy scenario so it will retrey to apply
    /// database migrations
    /// </summary>
    public static WebApplication ApplyDatabaseMigration<TContext>(this WebApplication app) where TContext : DbContext
    {
        // Apply database migration automatically. Note that this approach is not
        // recommended for production scenarios. Consider generating SQL scripts from
        // migrations instead.
        using var scope = app.Services.CreateScope();

        var retryPolicy = CreateRetryPolicy(app.Configuration, Log.Logger);
        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        retryPolicy.Execute(context.Database.Migrate);

        return app;
    }

    /// <summary>
    /// adds DbContext
    /// <param name="builder">this WebApplicationBuilder</param>
    /// <param name="connectionString">database connection string</param>
    /// <param name="isDevelopment">logs sensible data is only recommended in development enviroment</param>
    /// </summary>
    public static WebApplicationBuilder AddCustomDatabase<TContext>(
            this WebApplicationBuilder builder,
            string connectionString,
            bool isDevelopment
    ) where TContext : DbContext
    {
        builder.Services.AddDbContext<TContext>(options =>
        {
            options.EnableSensitiveDataLogging(isDevelopment);
            options.UseLazyLoadingProxies();
            options.UseNpgsql(connectionString);
        });

        if (isDevelopment)
        {
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        return builder;
    }

    private static Policy CreateRetryPolicy(IConfiguration configuration, Serilog.ILogger logger)
    {
        // Only use a retry policy if configured to do so.
        // When running in an orchestrator/K8s, it will take care of restarting failed services.
        if (bool.TryParse(configuration["RetryMigrations"], out bool retryMigrations))
        {
            return Policy.Handle<Exception>()
                .WaitAndRetryForever(
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, retry, timeSpan) =>
                    {
                        logger.Warning(
                            exception,
                            "Exception {ExceptionType} with message {Message} detected during database migration (retry attempt {retry})",
                            exception.GetType().Name,
                            exception.Message,
                            retry);
                    }
                );
        }

        return Policy.NoOp();
    }
    /// <summary>
    /// add the grapphql endpoint 
    /// </summary>
    public static WebApplication UseGraphQL(this WebApplication app)
    {
        app.UseWebSockets();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
            endpoints.MapControllers();
        });
        return app;
    }
}