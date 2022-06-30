namespace LasMarias.WareHouse.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public partial class MeasureUnitRepository : Repository<long, MeasureUnit>, IMeasureUnitRepository
{
    public MeasureUnitRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}