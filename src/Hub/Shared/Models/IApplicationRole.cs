using System;
using System.Collections.Generic;
using Orun.Domain;

namespace LasMarias.Hub.Domain.Models;

public interface IApplicationRole: IBusinessEntity<string>
{
    string Description { get; set; }
    
    ICollection<IWorker> Workers { get; set; }
}