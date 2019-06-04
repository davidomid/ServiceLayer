namespace ServiceLayer.Core
{
    public class NotFoundResult : HttpServiceResult
    {
        public NotFoundResult() : this(null)
        {
        }

        public NotFoundResult(params object[] errorDetails) : this((object)errorDetails)
        {
        }

        public NotFoundResult(object errorDetails) : base(HttpServiceResultTypes.NotFound, errorDetails)
        {
        }
    }
}
