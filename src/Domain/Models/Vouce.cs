namespace LasMarias.Domain.Models;

[GraphQLDescription("Vouce data, includes a set of products included")]
public partial class Vouce : BusinessEntity<long>
{
    public Vouce()
    {
        ProductMovements = new HashSet<ProductMovement>();
        StandType = Models.StandType.NotSpecified;
    }

    [GraphQLDescription("Id of vouce")]
    public long VouceId { get; set; }

    /// <summary>
    /// id of the user that authorize the vouce
    /// </summary>
    [GraphQLDescription("id of user that register the vouce")]
    public string? ApplicationUserId { get; set; }

    [GraphQLDescription("Application user that register the vouce")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public virtual ApplicationUser? ApplicationUser { get; set; }

    /// <summary>
    /// Notes about this vouce emition, just in case some special
    /// notes need to be included
    /// <summary>
    [GraphQLDescription("a simple note related with the Vouce")]
    public string? Note { get; set; }

    [GraphQLDescription("type of movement, entrance, exit or other")]
    public MovementType MovementType { get; set; }

    [GraphQLDescription("The type of stand describes the Stand where this Vouce was emmited to")]
    public Models.StandType? StandType { get; set; }

    /// <summary>
    /// list of products included in this vouce
    /// </summary>
    [GraphQLDescription("list of products moments include all data related with the product movements")]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement> ProductMovements { get; set; }
}