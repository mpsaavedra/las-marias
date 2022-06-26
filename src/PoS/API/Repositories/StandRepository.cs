namespace LasMarias.PoS.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;

public partial class StandRepository : Repository<long, Stand>, IStandRepository
{
    public StandRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}