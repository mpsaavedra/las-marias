namespace LasMarias.Profile.Domain.DataModels.Country;

[GraphQLDescription("basic data to update country")]
public class CountryUpdateInputModel
{
    [GraphQLDescription("Id of country")]
    public long Id { get; set; }

    [GraphQLDescription("Name")]
    public Optional<string> Name { get; set; }

    [GraphQLDescription("Country code")]
    public Optional<string> Code { get; set; }

    [GraphQLDescription("Region")]
    public Optional<Region> Region { get; set; }
}