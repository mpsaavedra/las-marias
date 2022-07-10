namespace LasMarias.WareHouse.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Repositories;

public partial class VouceRepository : Repository<long, Vouce>, IVouceRepository
{
    public VouceRepository(AutoMapper.IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}