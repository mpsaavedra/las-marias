namespace LasMarias.WareHouse.Filters;

using HotChocolate;

/// <summary>
/// A new Error handler filter to get a more information about
/// the error that happens in a GraphQL request.
/// </summary>
public class GraphQLErrorFilter : IErrorFilter
{
    /// <summary>
    /// returns the error information
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public IError OnError(IError error)
    {
        if (error.Exception != null)
            return error.WithMessage(error.Exception.Source + " " +
                                        error.Exception.Message + " " +
                                        error.Exception.StackTrace);
        return new Error(error.Message);
    }
}