namespace ServiceLayer.Core
{
    public class NotFoundResult : HttpServiceResult
    {
        public NotFoundResult() : base(HttpServiceResultTypes.NotFound)
        {
        }

        public NotFoundResult(params object[] errorDetails) : base(HttpServiceResultTypes.NotFound, errorDetails)
        {
        }
    }
}
