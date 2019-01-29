namespace ServiceLayer.Core
{
    public class BadRequestResult : HttpServiceResult
    {
        public BadRequestResult(params string[] errorMessages) : base(HttpServiceResultTypes.BadRequest, errorMessages)
        {
        }
    }
}
