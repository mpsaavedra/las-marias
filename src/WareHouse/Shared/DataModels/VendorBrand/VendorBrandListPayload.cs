namespace LasMarias.WareHouse.Domain.DataModels.VendorBrand;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class VendorBrandListPayload 
{
    public IQueryable<VendorBrand>? Payload { get; set; }
}