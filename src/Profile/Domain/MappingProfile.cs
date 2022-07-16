namespace LasMarias.Profile.Domain;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        // benefit mapping
        CreateMap<Domain.DataModels.Benefit.BenefitCreateInputModel, Domain.Models.Benefit>()
            .ReverseMap();
        CreateMap<Domain.DataModels.Benefit.BenefitUpdateInputModel, Domain.Models.Benefit>()
            .ReverseMap();

        // country
        CreateMap<Domain.DataModels.Country.CountryCreateInputModel, Domain.Models.Country>()
            .ReverseMap();
        CreateMap<Domain.DataModels.Country.CountryUpdateInputModel, Domain.Models.Country>()
            .ReverseMap();

        // employee
        CreateMap<Domain.DataModels.Employee.EmployeeCreateInputModel, Domain.Models.Employee>()
            .ReverseMap();
        CreateMap<Domain.DataModels.Employee.EmployeeCreateInputModel, Domain.Models.Employee>()
            .ReverseMap();

        // user
        CreateMap<Domain.DataModels.User.UserCreateInputModel, Domain.Models.User>()
            .ReverseMap();
        CreateMap<Domain.DataModels.User.UserUpdateInputModel, Domain.Models.User>()
            .ReverseMap();

    }
}