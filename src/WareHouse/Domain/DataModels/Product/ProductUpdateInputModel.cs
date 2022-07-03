namespace LasMarias.WareHouse.Domain.DataModels.Product;

public class ProductUpdateInputModel
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Note { get; set; }

    public decimal? Price { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? Amount { get; set; }

    public decimal? ReOrderLevel { get; set; }

    public ICollection<long>? AttributesIds { get; set; }

    public ICollection<long>? CategoriesIds { get; set; }

    public ICollection<long>? ProductPhotosIds { get; set; }

    public ICollection<long>? ProductBrandsIds { get; set; }
}