using LasMarias.Identity.Shared.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LasMarias.Identity.Domain.Models;

public partial class ApplicationRole: IdentityRole, IApplicationRole
{
    public string? Description { get; set; }
    
    [UseFiltering]
    [UseSorting]
    public virtual ICollection<IWorker> Workers { get; set; }

    #region Business entity members

    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Guid RowVersion { get; set; }

    #endregion
}