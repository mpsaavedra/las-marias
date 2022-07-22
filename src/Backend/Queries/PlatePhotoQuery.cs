namespace LasMarias.Queries;

[ExtendObjectType("Query")]
public partial class PlatePhotoQueries
{
    [GraphQLDescription("List all available PlatePhoto")]
    public async Task<IQueryable<PlatePhoto>> GetPlatePhotos(
        [Service] IChainOfResponsibilityService chain)
    {
        try
        {
            Log.Debug("PlatePhoto Query List: returns a PlatePhoto List");
            var data = new PlatePhotoListPayload();
            var fail = await chain.ExecuteAsyncChain<PlatePhotoListPayload, bool>(
                EventCodes.PlatePhotoList,
                data
            );
            return await Task.FromResult(data.Payload!);
        }
        catch (System.Exception ex)
        {
            Log.Error($"Exception while retrieving list of PlatePhoto: {ex.FullMessage()} ");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }

    }
}