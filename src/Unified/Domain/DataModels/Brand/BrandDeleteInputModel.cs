namespace LasMarias.Domain.DataModels.Brand;

[GraphQLDescription("basic data to delete a brand")]
public class BrandDeleteInputModel
{
    [GraphQLDescription("id of brand to delete")]
    public long Id { get; set; }
}