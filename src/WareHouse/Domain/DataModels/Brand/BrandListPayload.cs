namespace LasMarias.WareHouse.Domain.DataModels.Brand;

using System.Collections.Generic;
using LasMarias.WareHouse.Domain.Models;

public class BrandListPayload
{
    public IQueryable<Brand>? Payload { get; set; }
}