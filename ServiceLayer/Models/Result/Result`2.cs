using System;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Result<TResultType, TErrorType> : Result<TResultType>, IResult<TResultType, TErrorType> where TResultType : struct, Enum
    {
        public Result(TResultType resultType, TErrorType errorDetails) : base(resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator Result<TResultType, TErrorType>(SuccessResult successResult)
        {
            return Engine.ServiceResultFactory.Create<TResultType, TErrorType>(successResult);
        }

        public static implicit operator Result<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            return Engine.ServiceResultFactory.Create<TResultType, TErrorType>(failureResult);
        }

        public static implicit operator Result<TResultType, TErrorType>(TErrorType errorDetails)
        {
            return Engine.ServiceResultFactory.Create<TResultType, TErrorType>(errorDetails);
        }

        public static implicit operator Result<TResultType, TErrorType>(TResultType resultType)
        {
            return Engine.ServiceResultFactory.Create<TResultType, TErrorType>(resultType);
        }
    }
}