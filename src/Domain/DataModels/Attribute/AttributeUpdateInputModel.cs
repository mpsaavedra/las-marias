namespace LasMarias.Domain.DataModels.Attribute;

[GraphQLDescription("basic data to update an attribute")]
public class AttributeUpdateInputModel
{
    [GraphQLDescription("id of the attribute to update")]
    public long Id { get; set; }

    [GraphQLDescription("value of the attribute")]
    public Optional<string?> Value { get; set; }

    [GraphQLDescription("descrition of the attribute")]
    public Optional<string?> Description { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public Optional<long> MeasureUnitId { get; set; }

    [GraphQLDescription("id of the name attribute")]
    public Optional<long> AttributeNameId { get; set; }
}