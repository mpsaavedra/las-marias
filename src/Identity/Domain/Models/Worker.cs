using System.Text.Json.Serialization;
using LasMarias.Identity.Shared.Models;
using Orun.Domain;

namespace LasMarias.Identity.Domain.Models;

public partial class Worker: BusinessEntity<long>
{
    [JsonPropertyName("workerId")] 
    public long WorkerId { get; set; }

    [JsonPropertyName("applicationUserId")]
    public string ApplicationUserId { get; set; }

    [JsonPropertyName("roleId")] 
    public string RoleId { get; set; }

    public virtual WorkerStatus Status { get; set; }

    [UseFiltering]
    [UseSorting]
    [JsonIgnore] 
    public virtual ApplicationUser User { get; set; }
    
    [UseFiltering]
    [UseSorting]
    [JsonIgnore] 
    public virtual ApplicationRole Role { get; set; }

    [JsonPropertyName("hiredDate")]
    public DateTime HiredDate { get; set; }
}