namespace LasMarias.WareHouse.Domain.DataModels.ProductBrand;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class ProductBrandListPayload 
{
    public IQueryable<ProductBrand>? Payload { get; set; }
}