namespace LasMarias.Hub.Domain.InputModels.ApplicationUser;

public partial class UserCreateInputModel
{
    public string Id { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string DNI { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string NormalizedUserName { get; set; }

    public string NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }
}