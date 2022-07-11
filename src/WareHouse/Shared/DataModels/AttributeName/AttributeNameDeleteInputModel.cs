namespace LasMarias.WareHouse.Domain.DataModels.AttributeName;

using HotChocolate;

[GraphQLDescription("basic data to delete an attribute")]
public class AttributeNameDeleteInputModel
{
    [GraphQLDescription("id of attribute to delete")]
    public long Id { get; set; }
}
