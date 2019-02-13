using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType, TErrorType> : ServiceResult<TResultType>, IServiceResult<TResultType, TErrorType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, TErrorType errorDetails = default) : base(resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator ServiceResult<TResultType, TErrorType>(SuccessResult successResult)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new ServiceResult<TResultType, TErrorType>(resultType);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new ServiceResult<TResultType, TErrorType>(resultType);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(TErrorType errorDetails)
        {
            return new FailureResult<TErrorType>(errorDetails);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(TResultType resultType)
        {
            return new ServiceResult<TResultType, TErrorType>(resultType);
        }
    }
}