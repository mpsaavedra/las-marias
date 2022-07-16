namespace LasMarias.Profile.Domain.DataModels.Benefit;

[GraphQLDescription("returns a list of benefits")]
public partial class BenefitListPayload
{
    [GraphQLDescription("list of benefits")]
    public IQueryable<Models.Benefit>? Payload { get; set; }
}