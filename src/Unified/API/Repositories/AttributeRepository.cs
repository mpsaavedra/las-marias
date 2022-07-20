namespace LasMarias.Repositories;

public class AttributeRepository : Repository<long, Domain.Models.Attribute>, IAttributeRepository
{
    public AttributeRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
