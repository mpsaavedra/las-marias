using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using LasMarias.PoS.Filters;
// using LasMarias.PoS.Mutations;
using LasMarias.PoS.Queries;

namespace LasMarias.PoS.Extensions;

public static class GrahQlExtensions
{
    public static IServiceCollection AddGraphQlConfiguration(this IServiceCollection services)
    {
        
        // a custom Error filter to display more info bout the error
        // thi should be used only in debug
        services.AddErrorFilter<GraphQLErrorFilter>();
        
        // and here we go
        services
            .AddGraphQL()
            .AddQueryType(d => d.Name("Query"))
            .AddMutationType(m => m.Name("Mutation"))
            
            // add filters and navigations stuffs
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            
            // adding queries
            .AddType<AttributeQuery>()
            .AddType<AttributeNameQuery>()
            .AddType<CategoryQuery>()
            .AddType<ProductQuery>()
            .AddType<ProductPhotoQuery>()
            
            // adding mutations

            .ModifyOptions( o => o.RemoveUnreachableTypes = true);
       
        return services;
    }
}