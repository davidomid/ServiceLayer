namespace ServiceLayer
{
    public class FailureResult<TData> : ServiceResult<ServiceResultTypes, TData>
    {
        public FailureResult(params string[] errorMessages) : base(ServiceResultTypes.Failure, errorMessages: errorMessages)
        {
        }
    }
}
