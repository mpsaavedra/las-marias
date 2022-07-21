namespace LasMarias.Domain.DataModels.PlateProduct;

public class PlateProductListPayload
{
    public IQueryable<Domain.Models.PlateProduct>? Payload { get; set; }
}