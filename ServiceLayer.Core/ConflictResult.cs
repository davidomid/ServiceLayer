namespace ServiceLayer.Core
{
    public class ConflictResult : HttpServiceResult
    {
        public ConflictResult() : this(null)
        {
        }

        public ConflictResult(params object[] errorDetails) : this((object)errorDetails)
        {
        }

        public ConflictResult(object errorDetails) : base(HttpServiceResultTypes.Conflict, errorDetails)
        {
        }
    }
}
