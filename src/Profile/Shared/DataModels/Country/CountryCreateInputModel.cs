namespace LasMarias.Profile.Domain.DataModels.Country;

public class CountryCreateInputModel
{
    [GraphQLDescription("Name")]
    public string Name { get; set; }

    [GraphQLDescription("Country code")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("Country region")]
    public Region Region { get; set; }
}