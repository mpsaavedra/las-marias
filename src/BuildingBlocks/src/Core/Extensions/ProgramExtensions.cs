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
using Serilog;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

/// <summary>
/// Program extensions
/// </summary>
public static class ProgramExtensions
{
    /// <summary>
    /// add serilog logging
    /// </summary>
    public static WebApplicationBuilder AddCustomSerilog(
        this WebApplicationBuilder builder,
        string appName)
    {
        var seqServerUrl = builder.Configuration["SeqServerUrl"];

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.WithProperty("ApplicationName", appName)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate:
                // "[{Timestamp:HH:mm:ss} {Level:u3}] -({ApplicationName}) {Message:lj}{Exception}"
                "[{Timestamp:HH:mm:ss} {Level:u3}] - ({ApplicationName}) {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}"
            )
            .WriteTo.Seq(seqServerUrl)
            .CreateLogger();

        builder.Host.UseSerilog();
        return builder;
    }
}