using Microsoft.Extensions.DependencyInjection;
using LasMarias.PoS.Repositories;
using LasMarias.PoS.Domain.Repositories;

namespace LasMarias.PoS.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        
        // registering repositories
        
        return services;
    }
}