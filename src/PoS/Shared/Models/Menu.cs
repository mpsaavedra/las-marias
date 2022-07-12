namespace  LasMarias.PoS.Domain.Models;

using LasMarias.WareHouse.Domain.Models;

// TODO: move this entity into the restaurant service
[GraphQLDescription("Menu")]
public partial class Menu : BusinessEntity<long>
{
    [GraphQLDescription("id of the Menu")]
    public long MenuId { get; set; }
    
    [GraphQLDescription("Name of the menu")]
    public string Name { get; set; }

    [GraphQLDescription("if true menu is available")]
    public bool Available { get; set; }

    [GraphQLDescription("type of stand")]
    public virtual StandType StandType { get; set; }

    [GraphQLDescription("Plates the menu includes")]
    public virtual ICollection<MenuPlate> MenuPlates { get; set; }
}