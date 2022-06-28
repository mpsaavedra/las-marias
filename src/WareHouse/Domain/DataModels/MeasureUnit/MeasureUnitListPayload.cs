namespace LasMarias.WareHouse.Domain.DataModels;

using System.Collections.Generic;
using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitListPayload
{
    public IQueryable<MeasureUnit>? Payload { get; set; }
}