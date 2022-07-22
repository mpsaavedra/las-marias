namespace LasMarias.Domain.DataModels.Attribute;

[GraphQLDescription("basic data to create a new attribute")]
public class AttributeCreateInputModel
{
#pragma warning disable CS8618
    [GraphQLDescription("value of the attribute")]
    public string Value { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("description of the attribute")]
    public Optional<string> Description { get; set; }

    [GraphQLDescription("id of the measure unit")]
    public Optional<long> MeasureUnitId { get; set; }

    [GraphQLDescription("id of the attribute name")]
    public long AttributeNameId { get; set; }

    [GraphQLDescription("if true is available for the entire system")]
    public Optional<bool> Enable { get; set; }
}