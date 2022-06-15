namespace LasMarias.Hub.Domain.Models;

using System.Collections.Generic;
using Orun.Domain;

public interface IBenefit : IBusinessEntity<long>
{
    long BenefitId { get; set; }
    
    string Name { get; set; }
    
    string Description { get; set; }
    
    ICollection<IUserBenefit> UsersBenefits { get; set; }
}