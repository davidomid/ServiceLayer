namespace ServiceLayer.Core
{
    public class NotFoundResult : HttpServiceResult
    {
        public NotFoundResult(params string[] errorMessages) : base(HttpServiceResultTypes.NotFound, errorMessages)
        {
        }
    }
}
