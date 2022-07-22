namespace LasMarias.Domain.DataModels.Brand;


[GraphQLDescription("basic data to create a new brand")]
public class BrandCreateInputModel
{
#pragma warning disable CS8618
    [GraphQLDescription("name of the brand")]
    public string Name { get; set; }
#pragma warning restore CS8618

    [GraphQLDescription("if true brand is available to the system")]
    public Optional<bool> Enable { get; set; }
}