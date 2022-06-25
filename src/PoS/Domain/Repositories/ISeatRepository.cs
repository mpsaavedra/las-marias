namespace LasMarias.PoS.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Domain.Models;

public interface ISeatRepository : IRepository<long, Seat>
{

}