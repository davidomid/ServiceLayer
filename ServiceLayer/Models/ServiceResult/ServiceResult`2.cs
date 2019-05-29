using System;
namespace ServiceLayer
{
    public class ServiceResult<TResultType, TErrorType> : ServiceResult<TResultType>, IServiceResult<TResultType, TErrorType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, TErrorType errorDetails) : base(resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator ServiceResult<TResultType, TErrorType>(SuccessResult successResult)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType, TErrorType>(successResult);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType, TErrorType>(failureResult);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(TErrorType errorDetails)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType, TErrorType>(errorDetails);
        }

        public static implicit operator ServiceResult<TResultType, TErrorType>(TResultType resultType)
        {
            return ServiceResultConfiguration.ServiceResultFactory.Create<TResultType, TErrorType>(resultType);
        }
    }
}