﻿using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using LasMarias.WareHouse.Filters;
// using LasMarias.WareHouse.Mutations;
using LasMarias.WareHouse.Queries;

namespace LasMarias.WareHouse.Extensions;

public static class GrahQlExtensions
{
    public static IServiceCollection AddGraphQlConfiguration(this IServiceCollection services)
    {
        
        // a custom Error filter to display more info bout the error
        // thi should be used only in debug
        services.AddErrorFilter<GraphQLErrorFilter>();
        
        // and here we go
        services
            .AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            // .AddMutationType(m => m.Name("Mutation"))
            
            // add filters and navigations stuffs
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            
            // adding queries
            .AddType<AttributeQuery>()
            .AddType<AttributeNameQuery>()
            .AddType<CategoryQuery>()
            .AddType<PriceHistoryQuery>()
            .AddType<ProductQuery>()
            .AddType<ProductPhotoQuery>()
            
            // adding mutations

            .ModifyOptions( o => o.RemoveUnreachableTypes = true);
       
        return services;
    }

    public static WebApplication UseGraphQL(this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });
        return app;
    }
}