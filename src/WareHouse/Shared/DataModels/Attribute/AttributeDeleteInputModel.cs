namespace LasMarias.WareHouse.Domain.DataModels.Attribute;

using HotChocolate;

[GraphQLDescription("basic data to delete an atttribute")]
public class AttributeDeleteInputModel
{
    [GraphQLDescription("id of attribute to delete")]
    public long Id { get; set; }
}