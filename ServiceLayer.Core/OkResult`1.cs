namespace ServiceLayer.Core
{
    public class OkResult<TData> : HttpServiceResult<TData>
    {
        public OkResult(TData data) : base(HttpServiceResultTypes.Ok, data)
        {
        }
    }
}
