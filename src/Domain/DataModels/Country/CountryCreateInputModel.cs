namespace LasMarias.Domain.DataModels.Country;

public class CountryCreateInputModel
{
#pragma warning disable CS8618
    public string Name { get; set; }
#pragma warning restore CS8618

    public Optional<string> Code { get; set; }

    public Optional<int> PhoneCode { get; set; }

    public Optional<Region> Region { get; set; }
}