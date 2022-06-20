using LasMarias.Identity.Shared.InputModels.ApplicationUser;
using LasMarias.Identity.Shared.Models;

namespace LasMarias.Identity.Shared.InputModels.Worker;

public class WorkerInputModel
{
    public long WorkerId { get; set; }

    public string ApplicationUserId { get; set; }

    public WorkerStatus Status { get; set; }

    public string RoleId { get; set; }

    public DateTime HiredDate { get; set; }

    public UserCreateInputModel User { get; set; }
}