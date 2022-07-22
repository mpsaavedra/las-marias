namespace LasMarias.Domain.DataModels.PlateCategory;

public class PlateCategoryUpdateInputModel
{
    public Optional<long> PlateId { get; set; }

    public Optional<long> CategoryId { get; set; }
}