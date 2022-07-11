using LasMarias.Identity.Shared.Models.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace LasMarias.Identity.Domain.Models;

public partial class ApplicationRole: IdentityRole, IApplicationRole
{
    
    public string? Description { get; set; }
    
    [UseFiltering]
    [UseSorting]
    public virtual ICollection<IWorker> Workers { get; set; } = new HashSet<IWorker>();

    #region Business entity members

    public bool Deleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public string RowVersion { get; set; } = Guid.NewGuid().ToString();

    #endregion
}