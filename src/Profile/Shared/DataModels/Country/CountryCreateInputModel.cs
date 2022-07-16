namespace LasMarias.Profile.Domain.DataModels.Country;

public class CountryCreateInputModel
{
    public string? Name { get; set; }

    [GraphQLDescription("oficial country code or internet code")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("region country is located")]
    public Optional<Region> Region { get; set; }
}