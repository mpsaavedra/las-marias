namespace LasMarias.WareHouse.Domain.DataModels.Brand;

using System.Collections.Generic;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("response a list of brands")]
public class BrandListPayload
{
    [GraphQLDescription("list of brands")]
    public IQueryable<Brand>? Payload { get; set; }
}