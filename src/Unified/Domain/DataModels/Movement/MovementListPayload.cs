namespace LasMarias.Domain.DataModels.Movement;


[GraphQLDescription("retrieve a list of movements")]
public partial class MovementListPayload
{
    [GraphQLDescription("lsit of movements")]
    public IQueryable<Models.Movement>? Payload { get; set; }
}