namespace LasMarias.Profile.Domain.DataModels.Country;

using LasMarias.Profile.Domain.Models;

public class CountryListPayload
{
    public ICollection<Country>? Payload { get; set; }
}