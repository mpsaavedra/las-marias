namespace LasMarias.Hub.Domain.Models;

using Orun.Domain;

public interface IWorker : IBusinessEntity<string>
{
    long WorkerId { get; set; }

    string ApplicationUserId { get; set; }

    string RoleId { get; set; }

    WorkerStatus Status { get; set; }

    IApplicationUser User { get; set; }
    
    IApplicationRole Role { get; set; }

    DateTime HiredDate { get; set; }
}