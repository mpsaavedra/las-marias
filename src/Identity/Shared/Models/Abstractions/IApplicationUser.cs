using Orun.Domain;

namespace LasMarias.Identity.Shared.Models.Abstractions;

public interface IApplicationUser : IBusinessEntity<string>
{
    public string ReferralUserId { get; set; }
        
    string? ReferenceId { get; set; }
        
    long? CountryId { get; set; }
        
    string? FirstName { get; set; }
        
    string? LastName { get; set; }
        
    string? DNI { get; set; }
        
    string? PassportNumber { get; set; }
         
    Gender Gender { get; set; }
        
    IApplicationUser ReferralUser { get; set; }
        
    ICountry Country { get; set; }
        
    ICollection<IApplicationUser> ReferredUsers { get; set; }
        
    string? VerificationToken { get; set; }
        
    string? VerificationEmailToken { get; set; }
        
    ICollection<IUserBenefit> UserBenefits { get; set; }
}