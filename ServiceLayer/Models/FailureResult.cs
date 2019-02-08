namespace ServiceLayer
{
    public class FailureResult : FailureResult<object>
    {
        public FailureResult() : this(null)
        {
        }

        public FailureResult(params object[] errorDetails) : base(errorDetails)
        {
        }
    }
}
