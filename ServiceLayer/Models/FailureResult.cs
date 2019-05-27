namespace ServiceLayer
{
    public class FailureResult : ServiceResult
    {
        public FailureResult() : this(default)
        {
        }

        public FailureResult(params object[] errorDetails) : base(ServiceResultTypes.Failure, errorDetails)
        {
        }
    }
}
