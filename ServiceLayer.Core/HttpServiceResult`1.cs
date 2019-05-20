namespace ServiceLayer.Core
{
    public class HttpServiceResult<TData> : DataServiceResult<TData, HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, TData data) : base(data, resultType)
        {
        }

        public HttpServiceResult(HttpServiceResultTypes resultType, TData data, params object[] errorDetails) : base(data, resultType, errorDetails)
        {
        }
    }
}
