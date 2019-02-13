namespace ServiceLayer
{
    public class FailureResult : DataServiceResult<object, ServiceResultTypes, object>
    {
        public FailureResult() : this(default)
        {
        }

        public FailureResult(params object[] errorDetails) : base(default, ServiceResultTypes.Failure, errorDetails)
        {
        }
    }
}
