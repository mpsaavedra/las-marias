using System.Collections.Generic;
using Orun.Domain;

namespace LasMarias.PoS.Domain.Models;

public partial class Product : BusinessEntity<long>
{
    public long ProductId { get; set; }

    public string Name { get; set; }

    public string Decription { get; set; }
    
    public virtual ICollection<Attribute> Attributes { get; set; }

    public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    public virtual ICollection<Category> Categories { get; set; }
}