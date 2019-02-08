namespace ServiceLayer
{
    public class FailureResult<TErrorType> : FailureResult
    {
        public FailureResult() : this(default)
        {
        }

        public FailureResult(TErrorType errorDetails) : base(errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }
    }
}
