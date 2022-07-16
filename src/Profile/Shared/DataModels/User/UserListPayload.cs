namespace LasMarias.Profile.Domain.DataModels.User;

[GraphQLDescription("returns a list of users")]
public class UserListPayload
{
    [GraphQLDescription("list of users")]
    public IQueryable<Models.User>? Payload { get; set; }
}