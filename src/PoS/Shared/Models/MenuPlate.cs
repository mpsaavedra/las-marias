namespace LasMarias.PoS.Domain.Models;

[GraphQLDescription("defines the Menu plate relations")]
public partial class MenuPlate: BusinessEntity<long>
{
    [GraphQLDescription("Id of menu plate")]
    public long MenuPlateId{ get; set; }

    [GraphQLDescription("id of plate")]
    public long PlateId { get; set; }

    [GraphQLDescription("id of menu")]
    public long MenuId { get; set; }

    [GraphQLDescription("Plate")]
    public virtual Plate Plate { get; set; }

    [GraphQLDescription("Menu")]
    public virtual Menu Menu { get; set; }
}