namespace LasMarias.PoS.Domain.Models;

using System.Text.Json.Serialization;
using System.Collections.Generic;
using HotChocolate.Data;
using Orun.Domain;

public partial class Attribute : BusinessEntity<long>
{
    public Attribute()
    {
        Products = new HashSet<Product>();
    }

    public long AttributeId { get; set; }

    /// <summary>
    /// Value of the attribute
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// a simple description in case the attribute is meanningful of something 
    /// bigger
    /// </summary>
    public string? Description { get; set; }

    public long AttributeNameId { get; set; }

    public virtual AttributeName AttributeName { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}