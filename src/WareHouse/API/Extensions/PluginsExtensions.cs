namespace LasMarias.WareHouse.Extensions;

using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using LasMarias.WareHouse.Filters;
using LasMarias.WareHouse.Domain.Repositories;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.DataModels.Administration;
using LasMarias.WareHouse.Domain.DataModels.Attribute;
using LasMarias.WareHouse.Domain.DataModels.AttributeName;
using LasMarias.WareHouse.Domain.DataModels.Brand;
using LasMarias.WareHouse.Domain.DataModels.Category;
using LasMarias.WareHouse.Domain.DataModels.MeasureUnit;
using LasMarias.WareHouse.Domain.DataModels.Movement;
using LasMarias.WareHouse.Domain.DataModels.PriceHistory;
using LasMarias.WareHouse.Domain.DataModels.Product;
using LasMarias.WareHouse.Domain.DataModels.ProductBrand;
using LasMarias.WareHouse.Domain.DataModels.ProductMovement;
using LasMarias.WareHouse.Domain.DataModels.ProductPhoto;
using LasMarias.WareHouse.Domain.DataModels.Vendor;
using LasMarias.WareHouse.Domain.DataModels.VendorBrand;
using Orun.Extensions;
using Orun.Plugins;
using Orun.Services;
using Serilog;

public static class PluginsExtensions
{
    public static WebApplicationBuilder AddPluginsServices(this WebApplicationBuilder builder, string pluginsDir)
    {
        Log.Debug("Adding plugins services");
        builder.Services.AddPluginsService(
            pluginsDir,
            new []
            {
                typeof(IServiceCollection),
                typeof(IApplicationBuilder),
                typeof(IPlugin),

                // repositories
                typeof(IAttributeRepository),
                typeof(IAttributeNameRepository),
                typeof(ICategoryRepository),
                typeof(IMeasureUnitRepository),
                typeof(IMovementRepository),
                typeof(IPriceHistoryRepository),
                typeof(IProductBrandRepository),
                typeof(IProductMovementRepository),
                typeof(IProductPhotoRepository),
                typeof(IProductRepository),
                typeof(IVendorBrandRepository),
                typeof(IVendorRepository),

                // entities
                typeof(Attribute),
                typeof(AttributeName),
                typeof(Brand),
                typeof(Category),
                typeof(MeasureUnit),
                typeof(Movement),
                typeof(Movement),
                typeof(MovementType),
                typeof(PriceHistory),
                typeof(Product),
                typeof(ProductMovement),
                typeof(ProductBrand),
                typeof(ProductPhoto),
                typeof(StandType),
                typeof(Vendor),
                typeof(VendorBrand),

                // data models
                typeof(ProductNewMovementInputModel),

                typeof(AttributeCreateInputModel),
                typeof(AttributeListPayload),
                typeof(AttributeUpdateInputModel),
                typeof(AttributeDeleteInputModel),

                typeof(AttributeNameCreateInputModel),
                typeof(AttributeNameListPayload),
                typeof(AttributeNameUpdateInputModel),
                typeof(AttributeNameDeleteInputModel),

                typeof(BrandCreateInputModel),
                typeof(BrandListPayload),
                typeof(BrandUpdateInputModel),
                typeof(BrandDeleteInputModel),

                typeof(CategoryCreateInputModel),
                typeof(CategoryListPayload),
                typeof(CategoryUpdateInputModel),
                typeof(CategoryDeleteInputModel),

                typeof(MeasureUnitCreateInputModel),
                typeof(MeasureUnitListPayload),
                typeof(MeasureUnitUpdateInputModel),
                typeof(MeasureUnitDeleteInputModel),

                typeof(MovementCreateInputModel),
                typeof(MovementListPayload),
                typeof(MovementUpdateInputModel),
                typeof(MovementDeleteInputModel),

                typeof(PriceHistoryListPayload),

                typeof(ProductCreateInputModel),
                typeof(ProductListPayload),
                typeof(ProductUpdateInputModel),
                typeof(ProductDeleteInputModel),

                typeof(ProductBrandListPayload),

                typeof(ProductMovementListPayload),

                typeof(ProductPhotoListPayload),

                typeof(VendorCreateInputModel),
                typeof(VendorListPayload),
                typeof(VendorUpdateInputModel),
                typeof(VendorDeleteInputModel),
                
                typeof(VendorBrandListPayload)
            }
        );

        return builder;
    }

    public static WebApplication UsePlugIns(this WebApplication app)
    {
        app.ConfigurePlugins();
        return app;
    }
}