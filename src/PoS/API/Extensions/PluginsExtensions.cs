namespace LasMarias.PoS.Extensions;

public static class PluginsExtensions
{
    public static WebApplicationBuilder AddPluginsServices(this WebApplicationBuilder builder, string pluginsDir)
    {
        Log.Debug("PoS: Adding plugins services");
        builder.Services.AddPluginsService(
            pluginsDir,
            new[]
            {
                typeof(IServiceCollection),
                typeof(IApplicationBuilder),
                typeof(IPlugin),
                typeof(Serilog.Log),

                typeof(ICategoryRepository),
                typeof(IMenuRepository),
                typeof(IMenuPlateRepository),
                typeof(ICategoryRepository),
                typeof(IPlatePhotoRepository),
                typeof(IPlateProductRepository),
                typeof(IPlateRepository),
                typeof(ISeatRepository),
                typeof(IStandRepository),
                typeof(ITableRepository),

                typeof(Category),
                typeof(Menu),
                typeof(MenuPlate),
                typeof(PlatePhoto),
                typeof(PlateProduct),
                typeof(Plate),
                typeof(Seat),
                typeof(Stand),
                typeof(Table),

                typeof(CategoryListPayload),

                typeof(MenuListPayload),

                typeof(MenuListPayload),

                typeof(PlatePhotoListPayload),

                typeof(PlateProductListPayload),

                typeof(PlateListPayload),

                typeof(SeatListPayload),

                typeof(StandListPayload),

                typeof(TableListPayload)
            }
        );
        return builder;
    }
}