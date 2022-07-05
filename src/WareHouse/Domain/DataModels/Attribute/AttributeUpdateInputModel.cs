namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using HotChocolate;
using LasMarias.WareHouse.Domain.Models;

public class AttributeUpdateInputModel
{
    public long Id { get; set; }
    public Optional<string?> Value { get; set; }

    public Optional<string?> Description { get; set; }

    public Optional<long> MeasureUnitId { get; set; }

    public Optional<long> AttributeNameId { get; set; }
}