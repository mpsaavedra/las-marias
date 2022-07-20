namespace LasMarias.Repositories;

public class AttributeRepository : Repository<long, Domain.Models.Attribute>
{
    public AttributeRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
