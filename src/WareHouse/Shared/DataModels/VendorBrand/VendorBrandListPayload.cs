namespace LasMarias.WareHouse.Domain.DataModels.VendorBrand;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list vendor brands relations")]
public partial class VendorBrandListPayload 
{
    [GraphQLDescription("list of vendor brand")]
    public IQueryable<VendorBrand>? Payload { get; set; }
}