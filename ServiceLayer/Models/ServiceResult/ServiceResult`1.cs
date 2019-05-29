using System;

namespace ServiceLayer
{
    public class ServiceResult<TResultType> : ServiceResult, IServiceResult<TResultType> where TResultType : struct, Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, default)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public ServiceResult(TResultType resultType, object errorDetails) : base(resultType.ToResultType<ServiceResultTypes>(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator ServiceResult<TResultType>(SuccessResult successResult)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType>(successResult);
        }

        public static implicit operator ServiceResult<TResultType>(FailureResult failureResult)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType>(failureResult);
        }

        public static implicit operator ServiceResult<TResultType>(TResultType resultType)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create(resultType);
        }
    }
}