namespace ServiceLayer
{
    public class FailureResult<TErrorType> : ServiceResult<ServiceResultTypes, TErrorType>
    {
        public FailureResult(TErrorType errorDetails = default) : base(ServiceResultTypes.Failure, errorDetails)
        {
        }

        public static implicit operator ServiceResult(FailureResult<TErrorType> failureResult)
        {
            return new ServiceResult(failureResult.ResultType, failureResult.ErrorDetails);
        }
    }
}
