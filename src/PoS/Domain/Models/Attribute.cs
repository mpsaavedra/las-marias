namespace LasMarias.PoS.Domain.Models;

using System.Collections.Generic;
using Orun.Domain;

public partial class Attribute : BusinessEntity<long>
{
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

    public ICollection<Product> Products { get; set; }
}