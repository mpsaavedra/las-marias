namespace LasMarias.Domain.DataModels.Attribute;


[GraphQLDescription("list of attributes")]
public partial class AttributeListPayload
{
    [GraphQLDescription("list of attributes")]
    public IQueryable<Models.Attribute>? Payload { get; set; }
}