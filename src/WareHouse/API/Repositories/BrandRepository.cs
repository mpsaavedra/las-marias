namespace LasMarias.WareHouse.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public partial class BrandRepository : Repository<long, Brand>, IBrandRepository
{
    public BrandRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {

    }
}