namespace ServiceLayer.Core
{
    public class HttpServiceResult : CustomServiceResult<HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
