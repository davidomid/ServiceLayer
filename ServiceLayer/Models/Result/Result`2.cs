using System;
using ServiceLayer.Internal;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class Result<TResultType, TErrorType> : Result<TResultType>, IResult<TResultType, TErrorType> where TResultType : struct, Enum
    {
        public Result(TResultType resultType, TErrorType errorDetails) : base(resultType)
        {
            ErrorDetails = errorDetails;
        }

        public TErrorType ErrorDetails { get; }

        public static implicit operator Result<TResultType, TErrorType>(SuccessResult successResult)
        {
            return Engine.ResultFactory.Create<TResultType, TErrorType>(successResult);
        }

        public static implicit operator Result<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            return Engine.ResultFactory.Create<TResultType, TErrorType>(failureResult);
        }

        public static implicit operator Result<TResultType, TErrorType>(InconclusiveResult inconclusiveResult)
        {
            return Engine.ResultFactory.Create<TResultType, TErrorType>(inconclusiveResult);
        }

        public static implicit operator Result<TResultType, TErrorType>(TErrorType errorDetails)
        {
            return Engine.ResultFactory.Create<TResultType, TErrorType>(errorDetails);
        }

        public static implicit operator Result<TResultType, TErrorType>(TResultType resultType)
        {
            return Engine.ResultFactory.Create<TResultType, TErrorType>(resultType);
        }
    }
}