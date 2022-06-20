using LasMarias.Identity.Shared.Models.Abstractions;
using Orun.Domain;

namespace LasMarias.Identity.Domain.Models;

public partial class Benefit : BusinessEntity<long>, IBenefit
{
    public long BenefitId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public virtual ICollection<IUserBenefit> UsersBenefits { get; set; }
}