namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class ProductMovementQueries
{
    [GraphQLDescription("List all available ProductMovement")]
    public async Task<IQueryable<ProductMovement>> GetProductMovements(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("ProductMovement Query List: returns a ProductMovement List");
            var data = new ProductMovementListPayload();
            var fail = await chain.ExecuteAsyncChain<ProductMovementListPayload, bool>(
                EventCodes.ProductMovementList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of ProductMovement: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}
