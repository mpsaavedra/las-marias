namespace LasMarias.Domain.DataModels.Country;

public class CountryListPayload
{
    public IQueryable<Domain.Models.Country>? Payload { get; set; }
}