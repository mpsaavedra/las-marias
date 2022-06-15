using System;
using LasMarias.Hub.Domain.InputModels.ApplicationUser;
using LasMarias.Hub.Domain.Models;

namespace LasMarias.Hub.Domain.InputModels.Worker;

public class WorkerInputModel
{
    public long WorkerId { get; set; }

    public string ApplicationUserId { get; set; }

    public WorkerStatus Status { get; set; }

    public string RoleId { get; set; }

    public DateTime HiredDate { get; set; }

    public UserCreateInputModel User { get; set; }
}