namespace LasMarias.Domain.Models;

// relation m2m of plates ith categories
[GraphQLDescription("Plate category")]
public partial class PlateCategory : BusinessEntity<long>
{
    [GraphQLDescription("id of plate category")]
    public long PlateCategoryId { get; set; }

    [GraphQLDescription("id of plate")]
    public long? PlateId { get; set; }

    [GraphQLDescription("Id of category")]
    public long? CategoryId { get; set; }

    [GraphQLDescription("Plate")]
    public virtual Plate? Plate { get; set; }

    [GraphQLDescription("Category")]
    public virtual Category? Category { get; set; }
}