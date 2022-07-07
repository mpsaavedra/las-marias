namespace LasMarias.WareHouse.Domain.DataModels.MeasureUnit;

using LasMarias.WareHouse.Domain.Models;

public class MeasureUnitUpdateInputModel
{
    public long Id { get; set; }
    
    public string? Name { get; set; }

    public string? Code { get; set; }

    public Cast? Cast { get; set; }
}