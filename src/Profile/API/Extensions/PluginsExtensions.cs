namespace LasMarias.Profile.Extensions;

public static class PluginsExtensions
{
    public static WebApplicationBuilder AddPluginsServices(this WebApplicationBuilder builder, string pluginsDir)
    {
        Log.Debug("Profile: Adding plugins services");
        builder.Services.AddPluginsService(
            pluginsDir,
            new[]
            {
                typeof(IServiceCollection),
                typeof(IApplicationBuilder),
                typeof(IPlugin),
                typeof(Serilog.Log),

                typeof(IBenefitRepository),
                typeof(ICountryRepository),
                typeof(IEmployeeRepository),
                typeof(IUserRepository),
                typeof(IUserBenefitRepository),

                typeof(Benefit),
                typeof(Country),
                typeof(Employee),
                typeof(User),
                typeof(UserBenefit),

                typeof(BenefitCreateInputModel),
                typeof(CountryCreateInputModel),
                typeof(EmployeeCreateInputModel),
                typeof(UserCreateInputModel),
                typeof(UserBenefitCreateInputModel),

                typeof(BenefitUpdateInputModel),
                typeof(CountryUpdateInputModel),
                typeof(EmployeeUpdateInputModel),
                typeof(UserUpdateInputModel),

                typeof(BenefitListPayload),
                typeof(CountryListPayload),
                typeof(EmployeeListPayload),
                typeof(UserListPayload),
                typeof(UserBenefitListPayload),

                typeof(UserAddRemoveBenefitInputModel)
            }
        );

        return builder;
    }
}