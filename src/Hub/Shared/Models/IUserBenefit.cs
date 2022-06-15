using System.Collections.Generic;
using Orun.Domain;

namespace LasMarias.Hub.Domain.Models;

public interface IUserBenefit : IBusinessEntity<long>
{
    long UserBenefitId { get; set; }
    
    string ApplicationUserId { get; set; }
    
    long BenefitId { get; set; }
    
    IApplicationUser User { get; set; }
    
    IBenefit Benefit { get; set; }
    
    string Description { get; set; }
}