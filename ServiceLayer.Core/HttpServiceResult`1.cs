namespace ServiceLayer.Core
{
    public class HttpServiceResult<TData> : BaseServiceResult<HttpServiceResultTypes, TData>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, TData data, params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
