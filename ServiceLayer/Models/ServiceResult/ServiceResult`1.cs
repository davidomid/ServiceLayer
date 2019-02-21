using System;

namespace ServiceLayer
{
    public class ServiceResult<TResultType> : ServiceResult, IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, null)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public ServiceResult(TResultType resultType, object errorDetails) : base(resultType.ToServiceResultType(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator ServiceResult<TResultType>(SuccessResult successResult)
        {
            return ServiceResultFactory.Create<TResultType>(successResult);
        }

        public static implicit operator ServiceResult<TResultType>(FailureResult failureResult)
        {
            return ServiceResultFactory.Create<TResultType>(failureResult);
        }

        public static implicit operator ServiceResult<TResultType>(TResultType resultType)
        {
            return ServiceResultFactory.Create(resultType);
        }
    }
}