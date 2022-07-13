namespace LasMarias.Profile.Domain.DataModels.ApplicationUser;

using LasMarias.Profile.Domain.Models;

public class UserListPayload
{
    public ICollection<ApplicationUser>? Payload { get; set; }
}