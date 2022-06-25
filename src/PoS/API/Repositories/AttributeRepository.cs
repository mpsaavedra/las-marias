namespace LasMarias.PoS.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;

public partial class AttributeRepository : Repository<long, Attribute>, IAttributeRepository
{
    public AttributeRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}