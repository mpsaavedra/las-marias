using System.Collections.Generic;
using LasMarias.Hub.Domain.Models;
using Orun.Domain;

namespace LasMarias.Hub.Domain.Models;

public interface ICountry: IBusinessEntity<long>
{
    long CountryId { get; set; }
    
    string Name { get; set; }
    
    string Code { get; set; }
    
    Region Region { get; set; }
    
    ICollection<IApplicationUser> Users { get; set; }
}