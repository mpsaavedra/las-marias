namespace LasMarias.WareHouse.Domain.DataModels.Vouce;

using HotChocolate;

[GraphQLDescription("basic data to delete a vouce")]
public class VouceDeleteInputModel
{
    [GraphQLDescription("id of the vouce to delete")]
    public long Id { get; set; }
}