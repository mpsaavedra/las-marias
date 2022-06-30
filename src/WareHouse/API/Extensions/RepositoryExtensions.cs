using Microsoft.Extensions.DependencyInjection;
using LasMarias.WareHouse.Repositories;
using LasMarias.WareHouse.Domain.Repositories;

namespace LasMarias.WareHouse.Extensions;

public static class ReWareHouseitoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        
        // registering repositories
        services
            .AddScoped<IAttributeNameRepository, AttributeNameRepository>()
            .AddScoped<IAttributeRepository, AttributeRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<IPriceHistoryRepository, PriceHistoryRepository>()
            .AddScoped<IProductBrandRepository, ProductBrandRepository>()
            .AddScoped<IProductMovementRepository, ProductMovementRepository>()
            .AddScoped<IProductPhotoRepository, ProductPhotoRepository>()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IVendorBrandRepository, VendorBrandRepository>()
            .AddScoped<IVendorRepository, VendorRepository>();
        
        return services;
    }
}