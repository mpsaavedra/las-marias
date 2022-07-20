namespace LasMarias.Domain.DataModels.AttributeName;


[GraphQLDescription("basic data to delete an attribute")]
public class AttributeNameDeleteInputModel
{
    [GraphQLDescription("id of attribute to delete")]
    public long Id { get; set; }
}
