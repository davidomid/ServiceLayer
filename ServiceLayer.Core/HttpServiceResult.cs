namespace ServiceLayer.Core
{
    public class HttpServiceResult : GenericServiceResult<HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}
