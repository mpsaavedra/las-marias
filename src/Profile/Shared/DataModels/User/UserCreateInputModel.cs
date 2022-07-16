namespace LasMarias.Profile.Domain.DataModels.User;

public class UserCreateInputModel
{
    public string? ApplicationUserId { get; set; }

    public string? FirstName { get; set; }

    public Optional<string> LastName { get; set; }

    public Optional<string> DNI { get; set; }

    public Optional<string> PassportNumber { get; set; }

    public Optional<Gender> Gender { get; set; }

    public Optional<long> CountryId { get; set; }

    public Optional<EmployeeType> EmployeeType { get; set; }

    public Optional<DateOnly> DateOfBirth { get; set; }

    public Optional<EmployeeStatus> Status { get; set; }

    public Optional<DateOnly> HiredDate { get; set; }
}