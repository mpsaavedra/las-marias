namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitCreateInputModel 
{
    public string Name { get; set; }

    public string? Code { get; set; }

    public Cast? Cast { get; set; }

    public bool? Enable { get; set; }
}