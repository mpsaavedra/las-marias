namespace LasMarias.Domain.DataModels.Country;

public class CountryUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<string> Code { get; set; }

    public Optional<int> PhoneCode { get; set; }

    public Optional<Region> Region { get; set; }
}