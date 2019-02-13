namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType) : this(resultType, null)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params object[] errorDetails)
        {
            ResultType = resultType;
            ErrorDetails = errorDetails;
            IsSuccessful = resultType == ServiceResultTypes.Success;
        }

        public ServiceResultTypes ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful { get; }

        public static implicit operator ServiceResult(ServiceResultTypes serviceResultType)
        {
            return new ServiceResult(serviceResultType);
        }
    }
}