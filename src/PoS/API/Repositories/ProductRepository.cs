namespace LasMarias.PoS.Repositories;

using AutoMapper;
using Orun.BuildingBlocks.Domain;
using LasMarias.PoS.Data;
using LasMarias.PoS.Domain.Models;
using LasMarias.PoS.Domain.Repositories;

public partial class ProductRepository : Repository<long, Product>, IProductRepository
{
    public ProductRepository(IMapper mapper, ApplicationDbContext context): base(mapper, context)
    {
    }
}