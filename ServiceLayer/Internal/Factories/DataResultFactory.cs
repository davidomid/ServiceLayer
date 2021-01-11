using System;
using ServiceLayer.Models;

namespace ServiceLayer.Internal.Factories
{
    internal class DataResultFactory : IDataResultFactory
    {
        // top-level
        public DataResult<TData> Create<TData>(ResultType resultType)
        {
            return Create<TData, ResultType>(resultType);
        }

        // top-level
        public DataResult<TData> Create<TData>(TData data)
        {
            return Create<TData, ResultType>(data);
        }

        // top-level
        public DataResult<TData> Create<TData>(FailureResult failureResult)
        {
            return Create<TData, ResultType>(failureResult);
        }

        // top-level
        public DataResult<TData, TResultType> Create<TData, TResultType>(InconclusiveResult inconclusiveResult) where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(default, inconclusiveResult.ResultType);
        }

        public DataResult<TData, TResultType> Create<TData, TResultType>(SuccessResult<TData> successResult)
            where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(successResult.Data, successResult.ResultType);
        }

        // top-level
        public DataResult<TData, TResultType> Create<TData, TResultType>(TData data, TResultType resultType) where TResultType : struct, Enum
        {
            return new DataResult<TData,TResultType>(data, resultType);
        }

        // top-level
        public DataResult<TData, TResultType> Create<TData, TResultType>(Result<TResultType> result) where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(default, result.ResultType);
        }

        // top-level
        public DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data)
            where TResultType : struct, Enum
        {
            return Create<TData, TResultType, TErrorType>(data, ResultType.Success);
        }

        // top-level
        public DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            SuccessResult<TData> successResult) where TResultType : struct, Enum
        {
            return Create<TData, TResultType, TErrorType>(successResult.Data, successResult.ResultType);
        }

        // top-level
        public DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            FailureResult<TErrorType> failureResult) where TResultType : struct, Enum
        {
            return Create<TData, TResultType, TErrorType>(default, failureResult.ResultType,
                failureResult.ErrorDetails);
        }

        // top-level
        public DataResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TErrorType errorDetails) where TResultType : struct, Enum
        {
            return Create<TData, TResultType, TErrorType>(default, ResultType.Failure, errorDetails);
        }

        // top-level
        public DataResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TResultType resultType) where TResultType : struct, Enum
        {
            return Create<TData, TResultType, TErrorType>(default, resultType);
        }

        public DataResult<TData, TResultType> Create<TData, TResultType>(TData data) where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(data, ResultType.Success);
        }

        public DataResult<TData, TResultType> Create<TData, TResultType>(FailureResult failureResult)
            where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(default, failureResult.ResultType);
        }

        public DataResult<TData, TResultType> Create<TData, TResultType>(TResultType resultType)
            where TResultType : struct, Enum
        {
            return Create<TData, TResultType>(default, resultType);
        }

        private DataResult<TData, TResultType> Create<TData, TResultType>(TData data,
            ResultType resultType) where TResultType : struct, Enum
        {
            return new DataResult<TData,TResultType>(data, resultType.ToResultType<TResultType>());
        }

        private DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            ResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return Create(data, resultType.ToResultType<TResultType>(), errorDetails);
        }

        public DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            TResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return new DataResult<TData, TResultType, TErrorType>(data, resultType, errorDetails);
        }

        public DataResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(Result<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return new DataResult<TData, TResultType, TErrorType>(default, result.ResultType, result.ErrorDetails);
        }

        public DataResult<TData> Create<TData>(InconclusiveResult inconclusiveResult)
        {
            return new DataResult<TData>(default, inconclusiveResult.ResultType);
        }
    }
}