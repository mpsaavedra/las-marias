using System.Text.Json.Serialization;
using HotChocolate;
using LasMarias.Identity.Shared.Models.Abstractions;
using Orun.Domain;

namespace LasMarias.Identity.Domain.Models;

public partial class UserBenefit : BusinessEntity<long>, IUserBenefit
{
    [JsonPropertyName("userBenefitId")]
    public long UserBenefitId { get; set; }
    
    public string ApplicationUserId { get; set; }
    
    public long BenefitId { get; set; }
    
    [UseFiltering]
    [UseSorting]
    [JsonIgnore] 
    // [ForeignKe(nameof(ApplicationUserId))]
    public virtual IApplicationUser User { get; set; }
    
    [UseFiltering]
    [UseSorting]
    [JsonIgnore] 
    // [ForeignKey(nameof(BenefitId))]
    public virtual IBenefit Benefit { get; set; }
    
    [GraphQLDescription("Description of the cause of the cause of this benefit, some benefit requires of some identification of some type that it could be register in here")]
    public string Description { get; set; }
}