namespace LasMarias.WareHouse.Domain.DataModels.Vendor;

using System.Linq;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of vendors")]
public partial class VendorListPayload
{
    [GraphQLDescription("list of vendors")]
    public IQueryable<Vendor>? Payload { get; set; }
}