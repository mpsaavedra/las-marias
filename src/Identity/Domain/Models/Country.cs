using LasMarias.Identity.Shared.Models;
using LasMarias.Identity.Shared.Models.Abstractions;
using Newtonsoft.Json;
using Orun.Domain;

namespace LasMarias.Identity.Domain.Models;

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