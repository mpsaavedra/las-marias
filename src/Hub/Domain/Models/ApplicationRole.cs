using System;
using System.Collections.Generic;
using LasMarias.Hub.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Orun.BuildingBlocks.Domain;

namespace LasMarias.Hub.Domain.Models;

public partial class ApplicationRole: IdentityRole, IApplicationRole
{
    public string Description { get; set; }
    
    [UseFiltering]
    [UseSorting]
    public ICollection<IWorker> Workers { get; set; }

    #region Business entity members

    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    #endregion
}