namespace ServiceLayer
{
    public class FailureResult<TErrorType> : FailureResult
    {
        public FailureResult(TErrorType errorDetails = default) : base(errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }
    }
}
