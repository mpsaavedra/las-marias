namespace LasMarias.Domain.DataModels.AttributeName;


[GraphQLDescription("basic data to update an attribute name")]
public partial class AttributeNameUpdateInputModel
{
    [GraphQLDescription("id of the attribute name to update")]
    public long Id { get; set; }

    [GraphQLDescription("name of the attribute name")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("if true attribute name is available tot he system")]
    public Optional<bool> Enable { get; set; }
}