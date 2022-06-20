using Orun.Domain;

namespace LasMarias.Identity.Shared.Models.Abstractions;

public interface IApplicationRole: IBusinessEntity<string>
{
    string Description { get; set; }
    
    ICollection<IWorker> Workers { get; set; }
}