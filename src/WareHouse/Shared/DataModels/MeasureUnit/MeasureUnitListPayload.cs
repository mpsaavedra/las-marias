namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using System.Collections.Generic;
using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

[GraphQLDescription("returns a list of measure units")]
public class MeasureUnitListPayload
{
    [GraphQLDescription("list of measure units")]
    public IQueryable<MeasureUnit>? Payload { get; set; }
}