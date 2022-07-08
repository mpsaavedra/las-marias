namespace LasMarias.WareHouse.Domain.DataModels.Product;

using HotChocolate;

public class ProductUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<string> Note { get; set; }

    public Optional<decimal> Price { get; set; }

    public Optional<decimal> SellingPrice { get; set; }

    public Optional<decimal> Amount { get; set; }

    public Optional<decimal> ReOrderLevel { get; set; }

    public ICollection<long>? AttributesIds { get; set; }

    public ICollection<long>? CategoriesIds { get; set; }

    public ICollection<long>? ProductPhotosIds { get; set; }

    public ICollection<long>? ProductBrandsIds { get; set; }
}