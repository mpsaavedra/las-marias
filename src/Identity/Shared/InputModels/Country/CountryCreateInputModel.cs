using LasMarias.Identity.Shared.Models;

namespace LasMarias.Identity.Shared.InputModels.Country;

public partial class CountryCreateInputModel
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public Region Region { get; set; }
}