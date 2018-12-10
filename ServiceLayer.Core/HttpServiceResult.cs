namespace ServiceLayer.Core
{
    public class HttpServiceResult : ServiceResult<HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
