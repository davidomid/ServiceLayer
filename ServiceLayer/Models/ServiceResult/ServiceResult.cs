using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType) : this(resultType, default)
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

        internal static ISuccessResultFactory SuccessResultFactory =
            ServiceLocator.Instance.Resolve<ISuccessResultFactory>();

        internal static IFailureResultFactory FailureResultFactory =
            ServiceLocator.Instance.Resolve<IFailureResultFactory>();

        public static implicit operator ServiceResult(ServiceResultTypes serviceResultType)
        {
            return ServiceResultFactory.Create(serviceResultType);
        }
    }
}