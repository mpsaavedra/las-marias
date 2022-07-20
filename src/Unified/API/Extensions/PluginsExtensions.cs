public static class PluginsExtensions
{
    public static WebApplicationBuilder AddPluginsServices(this WebApplicationBuilder builder, string pluginsDir)
    {
        Log.Debug("Profile: Adding plugins services");
        builder.Services.AddPluginsService(
            pluginsDir,
            new[]
            {
                typeof(IServiceCollection),
                typeof(IApplicationBuilder),
                typeof(IPlugin),
                typeof(Serilog.Log),

                typeof(IApplicationUserRepository),
                typeof(IAttributeNameRepository),
                typeof(IAttributeRepository),
                typeof(IBrandRepository),
                typeof(ICategoryRepository),
                typeof(IMeasureUnitRepository),
                typeof(IMovementRepository),
                typeof(IPriceHistoryRepository),
                typeof(IProductBrandRepository),
                typeof(IProductPhotoRepository),
                typeof(IProductMovementRepository),
                typeof(IProductRepository),
                typeof(IVendorBrandRepository),
                typeof(IVendorRepository),
                typeof(IVouceRepository),

                typeof(ApplicationUser),
                typeof(AttributeName),
                typeof(Benefit),
                typeof(Brand),
                typeof(Category),
                typeof(Country),
                typeof(Employee),
                typeof(MeasureUnit),
                typeof(Menu),
                typeof(MenuPlate)
            }
        );

        return builder;
    }
}