using System.Collections.Generic;
using Orun.Domain;
using System.Text.Json.Serialization;
using HotChocolate.Data;

namespace LasMarias.WareHouse.Domain.Models;

public partial class Vendor : BusinessEntity<long>
{
    public long VendorId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public bool Enable { get; set; }

    public virtual ICollection<Movement> Movements { get; set; }
}