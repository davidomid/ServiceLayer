namespace ServiceLayer
{
    public class FailureResult : Result
    {
        public FailureResult() : this(default)
        {
        }

        public FailureResult(params object[] errorDetails) : base(ServiceLayer.ResultType.Failure, errorDetails)
        {
        }
    }
}
