namespace LasMarias.Domain.DataModels.Employee;

public class EmployeeUpdateInputModel
{
    public long Id { get; set; }

    public Optional<string> Name { get; set; }

    public Optional<string> Description { get; set; }

    public Optional<bool> Enable { get; set; }

    public Optional<decimal> DisccountAmount { get; set; }

    [GraphQLDescription("Where the benefit is applied to, default Cost")]
    public Optional<BenefitOver> Over { get; set; }

    public Optional<DateOnly> ReleaseDate { get; set; }

    public Optional<ReleaseReason> ReleaseReason { get; set; }

    public Optional<string> ReleaseNote { get; set; }
}