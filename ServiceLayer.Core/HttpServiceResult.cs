namespace ServiceLayer.Core
{
    public class HttpServiceResult : ServiceResult<HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType) : base(resultType, null)
        {
        }

        public HttpServiceResult(HttpServiceResultTypes resultType, params object[] errorDetails) : base(resultType, errorDetails)
        {
        }
    }
}
