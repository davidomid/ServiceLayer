using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType> : ServiceResult, IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType) : this(resultType, null)
        {
        }

        public ServiceResult(TResultType resultType, params object[] errorDetails) : base(resultType.ToServiceResultType(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator ServiceResult<TResultType>(SuccessResult successResult)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new ServiceResult<TResultType>(resultType);
        }

        public static implicit operator ServiceResult<TResultType>(FailureResult failureResult)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new ServiceResult<TResultType>(resultType);
        }

        public static implicit operator ServiceResult<TResultType>(TResultType resultType)
        {
            return new ServiceResult<TResultType>(resultType);
        }
    }
}