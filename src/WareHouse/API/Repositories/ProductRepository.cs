namespace LasMarias.WareHouse.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.WareHouse.Data;
using LasMarias.WareHouse.Domain.Models;
using LasMarias.WareHouse.Domain.Repositories;

public partial class ProductRepository : Repository<long, Product>, IProductRepository
{
    public ProductRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {
    }
}