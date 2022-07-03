namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using LasMarias.WareHouse.Domain.Models;

public class AttributeUpdateInputModel
{
    public string? Value { get; set; }

    public string? Description { get; set; }

    public long MeasureUnitId { get; set; }

    public long AttributeNameId { get; set; }
}