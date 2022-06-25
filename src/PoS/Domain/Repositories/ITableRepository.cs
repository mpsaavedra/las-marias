namespace LasMarias.PoS.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Domain.Models;

public interface ITableRepository: IRepository<long, Table>
{
    
}