namespace LasMarias.Domain.DataModels.AttributeName;

[GraphQLDescription("basic data to create an attribute name")]
public class AttributeNameCreateInputModel
{
#pragma warning disable CS8618    
    [GraphQLDescription("name of the attribute name")]
    public string Name { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("if true is available to the system")]
    public Optional<bool> Enable { get; set; }
}