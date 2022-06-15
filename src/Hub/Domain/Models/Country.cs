using System.Collections.Generic;
using LasMarias.Hub.Domain.Models;
using Newtonsoft.Json;
using Orun.Domain;

namespace LasMarias.Hub.Domain.Models;

public partial class Country: BusinessEntity<long>, ICountry
{
    public Country()
    {
        Region = Region.NotSpecified;
    }
    
    public long CountryId { get; set; }
    
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public Region Region { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<IApplicationUser> Users { get; set; }
}