namespace LasMarias.Repositories;

public class AttributeNameRepository : Repository<long, AttributeName>
{
    public AttributeNameRepository(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {

    }
}
