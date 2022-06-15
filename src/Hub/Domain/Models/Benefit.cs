using System.Collections.Generic;
using Orun.Domain;

namespace LasMarias.Hub.Domain.Models;

public partial class Benefit : BusinessEntity<long>, IBenefit
{
    public long BenefitId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public virtual ICollection<IUserBenefit> UsersBenefits { get; set; }
}