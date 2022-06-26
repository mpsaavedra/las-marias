using System.Collections.Generic;
using Orun.Domain;
using HotChocolate.Data;
using System.Text.Json.Serialization;

namespace LasMarias.WareHouse.Domain.Models;

/// <summary>
/// The attribute name class define the name of a given attribute providing the attribute
/// entity with a more flexible attributes set
/// </summary>
public partial class AttributeName : BusinessEntity<long>
{
    public AttributeName()
    {
        Attributes = new HashSet<Attribute>();
    }

    public long AttributeNameId { get; set; }

    /// <summary>
    /// Name of the attribute name
    /// </summary>
    public string Name { get; set; }

    public bool Enable { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Attribute> Attributes { get; set; }
}