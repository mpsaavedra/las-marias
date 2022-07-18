namespace LasMarias.PoS.Domain.DataModels.PlateProduct;

public partial class PlateProductListPayload
{
    public IQueryable<Models.PlateProduct>? Payload { get; set; }
}