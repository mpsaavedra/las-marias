using LasMarias.Hub.Domain.Models;

namespace LasMarias.Hub.Domain.InputModels.Country;
    
public partial class CountryCreateInputModel
{
    public string Name { get; set; }
    
    public string Code { get; set; }
    
    public Region Region { get; set; }
}