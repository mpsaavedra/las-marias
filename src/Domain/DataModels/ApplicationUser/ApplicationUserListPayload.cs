namespace LasMarias.Domain.DataModels.ApplicationUser;

public class ApplicationUserListPayload
{
    public IQueryable<Domain.Models.ApplicationUser>? Payload { get; set; }
}