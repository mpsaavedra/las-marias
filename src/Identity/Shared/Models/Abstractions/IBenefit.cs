using Orun.Domain;

namespace LasMarias.Identity.Shared.Models.Abstractions;

public interface IBenefit : IBusinessEntity<long>
{
    long BenefitId { get; set; }
    
    string Name { get; set; }
    
    string Description { get; set; }
    
    ICollection<IUserBenefit> UsersBenefits { get; set; }
}