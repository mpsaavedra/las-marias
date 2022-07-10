namespace LasMarias.WareHouse.Domain.Models;

using HotChocolate;
using HotChocolate.Data;
using System.Text.Json.Serialization;
using Orun.Domain;

public partial class Vouce : BusinessEntity<long>
{
    public Vouce()
    {
        ProductMovements = new HashSet<ProductMovement>();
    }

    public long VouceId { get; set; }

    /// <summary>
    /// id of the user that authorize the vouce
    /// </summary>
    public string ApplicationUser { get; set; }

    /// <summary>
    /// Notes about this vouce emition, just in case some special
    /// notes need to be included
    /// <summary>
    public string? Note { get; set; }

    
    public MovementType MovementType { get; set; }


    public StandType? StandType { get; set; }

    /// <summary>
    /// list of products included in this vouce
    /// </summary>
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductMovement> ProductMovements { get; set; }
}