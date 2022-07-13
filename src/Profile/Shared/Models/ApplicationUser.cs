using Microsoft.AspNetCore.Identity;

namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("system basic user data")]
public class ApplicationUser : IdentityUser, IBusinessEntity<string>
{
    public ApplicationUser()
    {
        Deleted = false;
        Enable = true;
        RowVersion = Guid.NewGuid().ToString();
        ReferredUsers = new HashSet<ApplicationUser>();
        Gender = Gender.NotDefined;
        Benefits = new HashSet<UserBenefit>();
    }
    [GraphQLDescription("id of user that reference business to this user")]
    public string? ReferralUserId { get; set; }

    [GraphQLDescription("id of the country")]
    public long? CountryId { get; set; }

    [GraphQLDescription("User first name")]
    public string? FirstName { get; set; }

    [GraphQLDescription("User last name")]
    public string? LastName { get; set; }

    [GraphQLDescription("National Id Document number")]
    [JsonPropertyName("dni")] 
    public string? DNI { get; set; }

    [GraphQLDescription("Passport number")]
    [JsonPropertyName("passportNumber")] 
    public string? PassportNumber { get; set; }

    [GraphQLDescription("Uer gender")]
    public Gender Gender { get; set; }

    [UseProjection]
    [UseSorting]
    public virtual ApplicationUser? ReferralUser { get; set; }

    [GraphQLDescription("Country of user")]
    [UseProjection]
    [UseSorting]
    public virtual Country? Country { get; set; }

    [GraphQLDescription("users referred by this user")]
    [UseProjection]
    [UseSorting]
    public virtual ICollection<ApplicationUser>? ReferredUsers { get; set; }

    [JsonIgnore]
    [GraphQLIgnore]
    public string? VerificationToken { get; set; }

    [JsonIgnore]
    [GraphQLIgnore]
    public string? VerificationEmailToken { get; set; }

    [GraphQLDescription("list of user benefits")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<UserBenefit>? Benefits { get; set; }

    [GraphQLDescription("if true user is active in the system")]
    public bool Enable { get; set; }

    [GraphQLDescription("Id of Employee if user is Employee")]
    public long? EmployeeId { get; set; }

    [GraphQLDescription("user data as Employee")]
    public virtual Employee? Employee { get; set; }


    #region Business entity members

    [GraphQLIgnore]
    public bool Deleted { get; set; }

    [GraphQLDescription("creation date")]
    public DateTimeOffset CreatedAt { get; set; }

    [GraphQLDescription("last modification date")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [GraphQLDescription("soft deletion date")]
    public DateTimeOffset? DeletedAt { get; set; }

    [GraphQLDescription("row version to avoid  creation conflicts ")]
    public string RowVersion { get; set; }

    #endregion
}
