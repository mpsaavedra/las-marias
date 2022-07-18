namespace LasMarias.Profile.Mutations;

using HotChocolate.Data;

public partial class CountryMutations
{
    [GraphQLDescription("Craetes a new country")]
    public async Task<Country> CountryCreate(
        CountryCreateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var country = await chain.ExecuteAsyncChain<CountryCreateInputModel, Country>(
                EventCodes.CountryCreate,
                input
            );
            return await Task.FromResult(country);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("updates an existing country with provided information")]
    public async Task<Country> CountryUpdate(
        CountryUpdateInputModel input,
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            var country = await chain.ExecuteAsyncChain<CountryUpdateInputModel, Country>(
                EventCodes.CountryUpdate,
                input
            );
            return await Task.FromResult(country);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }

    [GraphQLDescription("eletes an existing country from the system")]
    public async Task<bool> CountryDelete(long id, [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            var deleted = await chain.ExecuteAsyncChain<long, bool>(
                EventCodes.CountryDelete, id
            );
            return await Task.FromResult(deleted);
        }
        catch (Exception ex)
        {
            Log.Error($"Exception has occur while creating benefit: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}