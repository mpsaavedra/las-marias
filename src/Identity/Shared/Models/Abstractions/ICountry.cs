using Orun.Domain;

namespace LasMarias.Identity.Shared.Models.Abstractions;

public interface ICountry: IBusinessEntity<long>
{
    long CountryId { get; set; }
    
    string Name { get; set; }
    
    string Code { get; set; }
    
    Region Region { get; set; }
    
    ICollection<IApplicationUser> Users { get; set; }
}