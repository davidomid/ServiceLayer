namespace ServiceLayer.Core
{
    public class BadRequestResult : HttpServiceResult
    {
        public BadRequestResult() : this(null)
        {
        }

        public BadRequestResult(params object[] errorDetails) : this((object)errorDetails)
        {
        }

        public BadRequestResult(object errorDetails) : base(HttpServiceResultTypes.BadRequest, errorDetails)
        {
        }
    }
}
