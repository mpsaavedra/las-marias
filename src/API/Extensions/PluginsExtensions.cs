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
                typeof(IApplicationUserRepository),
                typeof(IAttributeNameRepository),
                typeof(IAttributeRepository),
                typeof(IBenefitRepository),
                typeof(IBrandRepository),
                typeof(ICategoryRepository),
                typeof(ICountryRepository),
                typeof(IEmployeeRepository),
                typeof(IMeasureUnitRepository),
                typeof(IMenuRepository),
                typeof(IMenuPlateRepository),
                typeof(IMovementRepository),
                typeof(IPlateRepository),
                typeof(IPlateCategoryRepository),
                typeof(IPlateProductRepository),
                typeof(IPriceHistoryRepository),
                typeof(IProductBrandRepository),
                typeof(IProductPhotoRepository),
                typeof(IProductMovementRepository),
                typeof(IProductRepository),
                typeof(ISeatRepository),
                typeof(IStandRepository),
                typeof(ITableRepository),
                typeof(IUserBenefitRepository),
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
                typeof(MenuPlate),
                typeof(Movement),
                typeof(Plate),
                typeof(PlateCategory),
                typeof(PlateProduct),
                typeof(PriceHistory),
                typeof(Product),
                typeof(ProductBrand),
                typeof(ProductMovement),
                typeof(ProductPhoto),
                typeof(Seat),
                typeof(Stand),
                typeof(Table),
                typeof(UserBenefit),
                typeof(Vendor),
                typeof(VendorBrand),
                typeof(Vouce)
            }
        );

        return builder;
    }
}