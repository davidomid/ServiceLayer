namespace ServiceLayer.Core
{
    public class BadRequestResult : HttpServiceResult
    {
        public BadRequestResult() : this(null)
        {
        }

        public BadRequestResult(params object[] errorDetails) : base(HttpServiceResultTypes.BadRequest, errorDetails)
        {
        }
    }
}
