namespace LasMarias.WareHouse;

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
using LasMarias.WareHouse.Domain.Models;

public partial class AutoMapping : AutoMapper.Profile
{
    public AutoMapping()
    {
        CreateMap<AttributeCreateInputModel, Attribute>().ReverseMap();
        CreateMap<AttributeUpdateInputModel, Attribute>().ReverseMap();
        
        CreateMap<AttributeNameCreateInputModel, AttributeName>().ReverseMap();
        CreateMap<AttributeNameUpdateInputModel, AttributeName>().ReverseMap();

        CreateMap<BrandCreateInputModel, Brand>().ReverseMap();
        CreateMap<BrandUpdateInputModel, Brand>().ReverseMap();

        CreateMap<CategoryCreateInputModel, Category>().ReverseMap();
        CreateMap<CategoryUpdateInputModel, Category>().ReverseMap();

        CreateMap<MeasureUnitCreateInputModel, MeasureUnit>().ReverseMap();
        CreateMap<MeasureUnitUpdateInputModel, MeasureUnit>().ReverseMap();

        CreateMap<MovementCreateInputModel, Movement>().ReverseMap();
        CreateMap<MovementUpdateInputModel, Movement>().ReverseMap();

        CreateMap<ProductCreateInputModel, Product>().ReverseMap();
        CreateMap<ProductUpdateInputModel, Product>().ReverseMap();

        CreateMap<VendorCreateInputModel, Vendor>().ReverseMap();
        CreateMap<VendorUpdateInputModel, Vendor>().ReverseMap();
    }
}