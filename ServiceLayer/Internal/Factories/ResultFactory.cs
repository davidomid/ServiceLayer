using System;
using ServiceLayer.Models;

namespace ServiceLayer.Internal.Factories
{
    internal class ResultFactory : IResultFactory
    {
        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType,
            TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return new Result<TResultType, TErrorType>(resultType, errorDetails);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default)
            where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(ResultType.Failure, errorDetails);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(successResult.ResultType);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult<TErrorType> failureResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(failureResult.ResultType, failureResult.ErrorDetails);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(InconclusiveResult inconclusiveResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(inconclusiveResult.ResultType);
        }

        public Result<TResultType> Create<TResultType>(TResultType resultType) where TResultType : struct, Enum
        {
            return Create<TResultType, object>(resultType);
        }

        public Result Create(ResultType resultType)
        {
            return Create<ResultType>(resultType);
        }

        public Result<TResultType> Create<TResultType>(Result result) where TResultType : struct, Enum
        {
            return Create<TResultType>(result.ResultType, result.ErrorDetails);
        }

        private Result<TResultType, TErrorType> Create<TResultType, TErrorType>(
            ResultType resultType,
            TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return Create(resultType.ToResultType<TResultType>(), errorDetails);
        }

        private Result<TResultType> Create<TResultType>(ResultType resultType, object errorDetails)
            where TResultType : struct, Enum
        {
            return Create<TResultType, object>(resultType, errorDetails);
        }
    }
}