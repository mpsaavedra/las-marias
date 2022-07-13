using Microsoft.AspNetCore.Identity;

namespace LasMarias.Profile.Domain.Models;

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

    public string? ReferralUserId { get; set; }

    public string? ReferenceId { get; set; }

    public long? CountryId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [JsonPropertyName("dni")] 
    public string? DNI { get; set; }

    [JsonPropertyName("passportNumber")] 
    public string? PassportNumber { get; set; }

    public Gender Gender { get; set; }

    [UseProjection]
    [UseSorting]
    public virtual ApplicationUser? ReferralUser { get; set; }

    [UseProjection]
    [UseSorting]
    public virtual Country? Country { get; set; }

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

    [GraphQLDescription("Id of worker if user is worker")]
    public long? WorkerId { get; set; }

    [GraphQLDescription("user data as worker")]
    public virtual Worker? Worker { get; set; }


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
