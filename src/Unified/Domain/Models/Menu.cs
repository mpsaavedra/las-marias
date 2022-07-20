namespace LasMarias.Domain.Models;

// TODO: move this entity into the restaurant service
[GraphQLDescription("Menu")]
public partial class Menu : BusinessEntity<long>
{
    public Menu()
    {
        MenuPlates = new HashSet<MenuPlate>();
        Name = "";
        Available = true;
        Offer = false;
        StandType = StandType.NotSpecified;
        SellingPrice = 0m;
    }

    public Menu(string name, string description)
    {
        MenuPlates = new HashSet<MenuPlate>();
        Name = name;
        Description = description;
        Available = true;
        Offer = false;
        StandType = StandType.NotSpecified;
        SellingPrice = 0m;
    }

    [GraphQLDescription("id of the Menu")]
    public long MenuId { get; set; }

    [GraphQLDescription("Name of the menu")]
    public string Name { get; set; }

    [GraphQLDescription("A basic description about the menu")]
    public string? Description { get; set; }

    [GraphQLDescription("if true menu is available")]
    public bool Available { get; set; }

    [GraphQLDescription("if true this menu in in offer")]
    public bool Offer { get; set; }

    [GraphQLDescription("type of stand")]
    public virtual StandType StandType { get; set; }

    [GraphQLDescription("Plates the menu includes")]
    public virtual ICollection<MenuPlate> MenuPlates { get; set; }

    [GraphQLDescription("Seling price of menu")]
    public decimal SellingPrice { get; set; }

    [GraphQLDescription("Menu production cost")]
    public decimal Cost =>
        MenuPlates.Sum(x => x.Cost);

    [GraphQLDescription("Menu selling price sum of all plates selling price")]
    public decimal BaseSellingPrice =>
        MenuPlates.Sum(x => x.SellingPrice);

    [GraphQLDescription("Earning by this late")]
    public decimal Earnings =>
        SellingPrice - Cost;
}