namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using System.Linq;
using LasMarias.WareHouse.Domain.Models;

public partial class VendorListPayload
{
    public IQueryable<Vendor>? Payload { get; set; }
}