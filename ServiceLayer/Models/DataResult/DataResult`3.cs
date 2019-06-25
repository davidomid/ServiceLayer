using System;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class DataResult<TData, TResultType, TErrorType> : DataResult<TData, TResultType>, IDataResult<TData, TResultType, TErrorType> where TResultType : struct, Enum
    {
        public DataResult(TData data, TResultType resultType, TErrorType errorDetails) : base(data, resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(TData data)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(data);
        }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(failureResult);
        }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(SuccessResult<TData> successResult)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(successResult);
        }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(TResultType resultType)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(resultType);
        }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(TErrorType errorDetails)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(errorDetails);
        }

        public static implicit operator DataResult<TData, TResultType, TErrorType>(
            Result<TResultType, TErrorType> result)
        {
            return Engine.DataResultFactory.Create<TData, TResultType, TErrorType>(result);
        }
    }
}