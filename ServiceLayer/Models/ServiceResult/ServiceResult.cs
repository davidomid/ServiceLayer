namespace ServiceLayer
{
    public class ServiceResult : ServiceResult<ServiceResultTypes>
    {
        public ServiceResult(ServiceResultTypes resultType) : base(resultType, null)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params object[] errorDetails) : base(resultType, errorDetails)
        {
        }

        public static implicit operator ServiceResult(FailureResult failureResult)
        {
            return new ServiceResult(failureResult.ResultType, failureResult.ErrorDetails);
        }
    }
}