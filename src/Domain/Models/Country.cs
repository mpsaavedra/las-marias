
namespace LasMarias.Domain.Models;

[GraphQLDescription("Country")]
public partial class Country : BusinessEntity<long>
{
    public Country()
    {
        Region = Region.NotSpecified;
        Users = new HashSet<ApplicationUser>();
        Name = "";
        Code = "";
    }

    public Country(string name, string code, Region region)
    {
        Name = name;
        Code = code;
        Region = region;
        Users = new HashSet<ApplicationUser>();
    }

    [GraphQLDescription("id of country")]
    public long CountryId { get; set; }

    [GraphQLDescription("Official name of the country")]
    public string Name { get; set; }

    [GraphQLDescription("short code of the country: like CU for Cuba")]
    public string? Code { get; set; }

    [GraphQLDescription("phone code")]
    public int PhoneCode { get; set; }

    [GraphQLDescription("Region this country belongs to")]
    public Region Region { get; set; }

    [GraphQLDescription("list of users in this country")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ApplicationUser> Users { get; set; }
}