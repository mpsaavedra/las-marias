namespace LasMarias.Profile.Domain.DataModels.Country;

[GraphQLDescription("returns a list of countries")]
public class CountryListPayload
{
    [GraphQLDescription("list of countries")]
    public IQueryable<Models.Country>? Payload { get; set; }
}