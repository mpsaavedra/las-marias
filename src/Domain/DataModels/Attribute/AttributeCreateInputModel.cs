namespace LasMarias.Domain.DataModels.Attribute;

[GraphQLDescription("basic data to create a new attribute")]
public class AttributeCreateInputModel
{
    public AttributeCreateInputModel()
    {
        Value = "";
    }

    [GraphQLDescription("value of the attribute")]
    public string Value { get; set; }

    [GraphQLDescription("description of the attribute")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public Optional<long> MeasureUnitId { get; set; }

    [GraphQLDescription("id of the attribute name")]
    public long AttributeNameId { get; set; }
}