namespace LasMarias.Profile.Domain.Models;

[GraphQLDescription("Country")]
public partial class Country : BusinessEntity<long>
{
    public Country()
    {
        Region = Region.NotSpecified;
    }
    [GraphQLDescription("id of country")]
    public long CountryId { get; set; }
    
    [GraphQLDescription("Official name of the country")]
    public string Name { get; set; }
    
    [GraphQLDescription("short code of the country: like CU for Cuba")]
    public string Code { get; set; }
    
    [GraphQLDescription("Region this country belongs to")]
    public Region Region { get; set; }
    
    [GraphQLDescription("list of users in this country")]
    [UseProjection]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ApplicationUser> Users { get; set; }
}