namespace LasMarias.Domain.DataModels.Brand;

[GraphQLDescription("basic data to update a brand")]
public class BrandUpdateInputModel
{
    [GraphQLDescription("id of the brand to update")]
    public long Id { get; set; }

    [GraphQLDescription("name of the Brand")]
    public Optional<string?> Name { get; set; }

    [GraphQLDescription("if true brand is available tot he system")]
    public Optional<bool?> Enable { get; set; }
}