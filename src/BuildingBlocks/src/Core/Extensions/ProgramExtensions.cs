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
using Orun.Filters;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Projections;
using HotChocolate.Data.Sorting;
using HotChocolate.Execution.Configuration;

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

    /// <summary>
    /// adds custom graphql objects and other types.
    /// </summary>
    //  builder
    //     .AddCustomGraphQL(
    //         queries =>
    //             queries
    //                 .AddType<EmployeeQueries>()
    //                 .AddType<EarningQueries>(),
    //         mutations =>
    //             mutations
    //                 .AddType<EmployeeMutations>()
    //     );
    public static IRequestExecutorBuilder AddCustomGraphQL(
        this WebApplicationBuilder builder,
        bool isDevelopmentEnvironment,
        Action<IRequestExecutorBuilder>? queries = null,
        Action<IRequestExecutorBuilder>? mutations = null,
        Action<IRequestExecutorBuilder>? subscriptions = null
    )
    {
        // a custom Error filter to display more info bout the error
        // thi should be used only in debug
        builder.Services.AddErrorFilter<GraphQLErrorFilter>();

        var executor = builder.Services
            .AddGraphQLServer()
            .AddFiltering()
            .AddSorting()
            .AddProjections();

        if (queries != null)
        {
            executor.AddQueryType(d => d.Name("Query"));
            queries.Invoke(executor);
        }

        if (mutations != null)
        {
            executor.AddMutationType(s => s.Name("Mutation"));
            mutations.Invoke(executor);
        }

        if (subscriptions != null)
        {
            executor.AddSubscriptionType(d => d.Name("Subscription"));
            subscriptions.Invoke(executor);
        }

        executor
            .ModifyOptions(o =>
            {
                o.RemoveUnreachableTypes = true;
            })
            .ModifyRequestOptions(opts =>
            {
                opts.IncludeExceptionDetails = isDevelopmentEnvironment;
            });

        return executor;
    }
}