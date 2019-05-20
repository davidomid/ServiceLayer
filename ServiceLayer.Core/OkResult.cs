namespace ServiceLayer.Core
{
    public class OkResult : HttpServiceResult
    {
        public OkResult() : base(HttpServiceResultTypes.Ok)
        {
        }
    }
}
