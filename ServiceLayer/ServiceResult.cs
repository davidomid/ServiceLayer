using ServiceLayer.Internal;

namespace ServiceLayer
{
    public abstract class ServiceResult
    {
        protected ServiceResult(ServiceResultTypes resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public ServiceResultTypes ResultType { get; }

        public static ServiceResult Create(ServiceResultTypes resultType, params string[] errorMessages)
        {
            return new InternalServiceResult(resultType, errorMessages);
        }
    }
}