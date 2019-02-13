using System;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType, TErrorType> : DataServiceResult<TData, TResultType>, IDataServiceResult<TData, TResultType, TErrorType> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType, TErrorType errorDetails = default) : base(data, resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TData data)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, failureResult.ErrorDetails);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(SuccessResult<TData> successResult)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TResultType resultType)
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TErrorType errorDetails)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, errorDetails);
        }
    }
}