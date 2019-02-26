using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType) : this(resultType, null)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public ServiceResult(ServiceResultTypes resultType, object errorDetails)
        {
            ResultType = resultType;
            ErrorDetails = errorDetails;
            IsSuccessful = resultType == ServiceResultTypes.Success;
        }

        public ServiceResultTypes ResultType { get; }
        public object ErrorDetails { get; }
        public bool IsSuccessful { get; }

        internal static IServiceResultFactory ServiceResultFactory = ServiceLocator.Instance.Resolve<IServiceResultFactory>();

        internal static IDataServiceResultFactory DataServiceResultFactory =
            ServiceLocator.Instance.Resolve<IDataServiceResultFactory>();

        public static implicit operator ServiceResult(ServiceResultTypes serviceResultType)
        {
            return ServiceResultFactory.Create(serviceResultType);
        }
    }
}