using Microsoft.Extensions.DependencyInjection;
using LasMarias.PoS.Repositories;
using LasMarias.PoS.Domain.Repositories;

namespace LasMarias.PoS.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        
        // registering repositories
        services
            .AddScoped<ISeatRepository, SeatRepository>()
            .AddScoped<IStandRepository, StandRepository>()
            .AddScoped<ITableRepository, TableRepository>();
        
        return services;
    }
}