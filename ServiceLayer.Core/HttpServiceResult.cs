namespace ServiceLayer.Core
{
    public class HttpServiceResult : BaseServiceResult<HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
