namespace ServiceLayer.Core
{
    public class BadRequestResult : HttpServiceResult
    {
        public BadRequestResult() : base(HttpServiceResultTypes.BadRequest)
        {
        }

        public BadRequestResult(params object[] errorDetails) : base(HttpServiceResultTypes.BadRequest, errorDetails)
        {
        }
    }
}
