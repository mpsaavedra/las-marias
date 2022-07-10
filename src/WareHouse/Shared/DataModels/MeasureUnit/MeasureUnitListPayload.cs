namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using System.Collections.Generic;
using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitListPayload
{
    public IQueryable<MeasureUnit>? Payload { get; set; }
}