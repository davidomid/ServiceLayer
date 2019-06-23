using System;

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
            return Create<TResultType, TErrorType>(ResultTypes.Failure, errorDetails);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(successResult.ResultType);
        }

        public Result<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult<TErrorType> failureResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(failureResult.ResultType, failureResult.ErrorDetails);
        }

        public Result<TResultType> Create<TResultType>(TResultType resultType) where TResultType : struct, Enum
        {
            return Create<TResultType, object>(resultType);
        }

        public Result Create(ResultTypes resultType)
        {
            return Create<ResultTypes>(resultType);
        }

        public Result<TResultType> Create<TResultType>(Result result) where TResultType : struct, Enum
        {
            return Create<TResultType>(result.ResultType, result.ErrorDetails);
        }

        private Result<TResultType, TErrorType> Create<TResultType, TErrorType>(
            ResultTypes resultType,
            TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return Create(resultType.ToResultType<TResultType>(), errorDetails);
        }

        private Result<TResultType> Create<TResultType>(ResultTypes resultType, object errorDetails)
            where TResultType : struct, Enum
        {
            return Create<TResultType, object>(resultType, errorDetails);
        }
    }
}