namespace LasMarias.Domain.DataModels.AttributeName;

[GraphQLDescription("response data of the attribute name list")]
public partial class AttributeNameListPayload
{
    [GraphQLDescription("list of name of attributes")]
    public IQueryable<Models.AttributeName>? Payload { get; set; }
}