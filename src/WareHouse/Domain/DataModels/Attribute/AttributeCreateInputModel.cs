namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class AttributeCreateInputModel
{
    public string Value { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<long> MeasureUnitId { get; set; }

    public long AttributeNameId { get; set; }
}