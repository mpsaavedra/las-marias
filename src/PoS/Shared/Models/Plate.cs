namespace LasMarias.PoS.Domain.Models;


// TODO: move this entity into the restaurant service
[GraphQLDescription("A plate offer in the menu. it could also refer to drinks or else")]
public partial class Plate: BusinessEntity<long>
{
    public Plate()
    {
        PlateProducts = new HashSet<PlateProduct>();
        PlatePhotos = new HashSet<PlatePhoto>();
        SellingPrice = 0;
    }

    [GraphQLDescription("Id of plate")]
    public long PlateId { get; set; }

    [GraphQLDescription("Plate's name")]
    public string Name { get; set; }

    [GraphQLDescription("Description")]
    public string? Description { get; set; }

    [GraphQLDescription("Recipe explaining how the plate is created, plates could also refer to drinks or else")]
    public string? Recipe { get; set; }

    [GraphQLDescription("list of plate products")]
    public virtual ICollection<PlateProduct> PlateProducts { get; set; }

    [GraphQLDescription("list of relation menu plates")]
    public virtual ICollection<MenuPlate> MenuPlates { get; set; }

    [GraphQLDescription("price to sale the plate")]
    public decimal SellingPrice { get; set; }

    [GraphQLDescription("if true is available")]
    public bool Available { get; set; }

    [GraphQLDescription("plate categories")]
    public virtual ICollection<PlateCategory>? PlateCategories { get; set; }

    [GraphQLDescription("lilst of relation of plate photos")]
    [UseFiltering]
    [UseSorting]
    [JsonIgnore]
    public virtual ICollection<PlatePhoto>? PlatePhotos { get; set; }

    [GraphQLDescription("Cost price of plate using product cost price")]
    public decimal Cost
    {
        get 
        {
            decimal price = 0;
            foreach(var pp in PlateProducts)
            {
                price += (pp.Product.Price * pp.Amount);
            }

            return price;
        }
    }
}