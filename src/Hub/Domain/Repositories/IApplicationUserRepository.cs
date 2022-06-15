using LasMarias.Hub.Domain.Models;
using Orun.BuildingBlocks.Domain;

namespace LasMarias.Hub.Domain.Repositories;

public interface IApplicationUserRepository: IRepository<string, ApplicationUser>
{

}