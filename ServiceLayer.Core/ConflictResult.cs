namespace ServiceLayer.Core
{
    public class ConflictResult : HttpServiceResult
    {
        public ConflictResult() : base(HttpServiceResultTypes.Conflict)
        {
        }

        public ConflictResult(params object[] errorDetails) : base(HttpServiceResultTypes.Conflict, errorDetails)
        {
        }
    }
}
