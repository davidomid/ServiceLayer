namespace ServiceLayer
{
    public class FailureResult : Result
    {
        public FailureResult() : this(default)
        {
        }

        public FailureResult(params object[] errorDetails) : base(ResultTypes.Failure, errorDetails)
        {
        }
    }
}
