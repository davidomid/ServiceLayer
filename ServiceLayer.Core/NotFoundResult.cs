namespace ServiceLayer.Core
{
    public class NotFoundResult : HttpServiceResult
    {
        public NotFoundResult() : this(null)
        {
        }

        public NotFoundResult(params object[] errorDetails) : base(HttpServiceResultTypes.NotFound, errorDetails)
        {
        }
    }
}
