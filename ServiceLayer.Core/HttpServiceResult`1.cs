namespace ServiceLayer.Core
{
    public class HttpServiceResult<TData> : DataServiceResult<TData, HttpServiceResultTypes>
    {
        public HttpServiceResult(HttpServiceResultTypes resultType, TData data, params string[] errorMessages) : base(resultType, data, errorMessages)
        {
        }
    }
}
