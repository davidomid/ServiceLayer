namespace ServiceLayer.Core
{
    public class ConflictResult : HttpServiceResult
    {
        public ConflictResult(params string[] errorMessages) : base(HttpServiceResultTypes.Conflict, errorMessages)
        {
        }
    }
}
