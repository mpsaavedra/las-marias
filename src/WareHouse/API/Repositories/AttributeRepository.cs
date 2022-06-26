namespace LasMarias.WareHouse.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public partial class AttributeRepository : Repository<long, Attribute>, IAttributeRepository
{
    public AttributeRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}