namespace LasMarias.WareHouse.Domain.DataModels.Product;

using HotChocolate;

public class ProductCreateInputModel
{
    public string Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<string> Note { get; set; }

    public decimal Price { get; set; }

    public decimal SellingPrice { get; set; }

    public Optional<decimal> Amount { get; set; }

    public Optional<decimal> ReOrderLevel { get; set; }

    public long MeasureUnitId { get; set; }

    public ICollection<long>? AttributesIds { get; set; }

    public ICollection<long>? CategoriesIds { get; set; }

    public ICollection<long>? ProductPhotosId { get; set; }

    public ICollection<long>? ProductBrandsId { get; set; }
}