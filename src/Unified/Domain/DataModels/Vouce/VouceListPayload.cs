namespace LasMarias.Domain.DataModels.Vouce;


[GraphQLDescription("returns a list of vouces")]
public partial class VouceListPayload
{
    [GraphQLDescription("list of vouces")]
    public IQueryable<Models.Vouce>? Payload { get; set; }
}