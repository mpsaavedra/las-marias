using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.PoS.Domain.Models;

public partial class Product : BusinessEntity<long>
{
    public long ProductId { get; set; }

    public string Name { get; set; }

    public string Decription { get; set; }
    
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Attribute> Attributes { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<Category> Categories { get; set; }
}