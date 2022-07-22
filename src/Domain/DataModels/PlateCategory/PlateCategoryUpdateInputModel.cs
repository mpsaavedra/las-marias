namespace LasMarias.Domain.DataModels.PlateCategory;

public class PlateCategoryUpdateInputModel
{

    public long Id { get; set; }
    public Optional<long> PlateId { get; set; }

    public Optional<long> CategoryId { get; set; }
}