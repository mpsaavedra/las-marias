namespace LasMarias.PoS.Queries;

[ExtendObjectType("Query")]
[GraphQLDescription("PlatePhoto queries")]
public partial class PlatePhotoQuery
{
    [UseFirstOrDefault]
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("List all available PlatePhoto")]
    public async Task<IQueryable<PlatePhoto>> GetPlatePhotos(
        [Service] IChainOfResponsibilityService chain
    )
    {
        try
        {
            Log.Debug("Retrieving PlatePhotos list");
            var data = new PlatePhotoListPayload();
            var fail = await chain.ExecuteAsyncChain<PlatePhotoListPayload, bool>(
                EventCodes.PlatePhotoList, data);
            return await Task.FromResult(data.Payload!);
        }
        catch (Exception ex)
        {
            Log.Error($"An exception occurs while listing Catagory: {ex.FullMessage()}");
            Insist.Throw<Exception>(ex.FullMessage());
            throw;
        }
    }
}