using System;
using System.Linq;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType, TErrorType> : ServiceResult<TResultType, TErrorType>, IDataServiceResult<TData, TResultType, TErrorType> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType, TErrorType errorDetails = default) : base(resultType, errorDetails)
        {
            this.Data = data;
        }

        public TData Data { get; }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TData data)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType, default);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, failureResult.ErrorDetails);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TResultType resultType)
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, default);
        }
    }
}