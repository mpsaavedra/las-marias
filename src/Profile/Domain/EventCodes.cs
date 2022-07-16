namespace LasMarias.Profile.Domain;

/// <summary>
/// List of event names as constants, this event codes will be used
/// in the evencode property of all business logic plugins and the
/// chain of responsibility calls
/// </summary>
public class EventCodes
{
    #region Benefits

    public static string BenefitCreate = "benefit-create";

    public static string BenefitList = "benefit-list";

    public static string BenefitUpdate = "benefit-update";

    public static string BenefitDelete = "benefit-delete";

    #endregion

    #region Countries

    public static string CountryCreate = "country-create";

    public static string CountryList = "country-list";

    public static string CountryUpdate = "country-update";

    public static string CountryDelete = "country-delete";
    #endregion

    #region Employees

    public static string EmployeeCreate = "employee-create";

    public static string EmployeeList = "employee-list";

    public static string EmployeeUpdate = "employee-update";

    public static string EmployeeDelete = "employee-delete";
    #endregion

    #region User

    public static string UserCreate = "user-create";

    public static string UserList = "user-list";

    public static string UserUpdate = "user-update";

    public static string UserDelete = "user-delete";

    public static string UserAddRemoveBenefit = "user-add-remove-benefit";

    #endregion

    #region UserBenefit

    public static string UserBenefitCreate = "user-benefit-create";

    public static string UserBenefitList = "user-benefit-list";

    public static string UserBenefitUpdate = "user-benefit-update";

    public static string UserBenefitDelete = "user-benefit-delete";

    #endregion
}