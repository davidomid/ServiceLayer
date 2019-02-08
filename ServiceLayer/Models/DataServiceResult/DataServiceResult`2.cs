using System;
using System.Linq;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : DataServiceResult<TData, TResultType, object> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType) : base(data, resultType)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, params object[] errorDetails) : base(data, resultType, errorDetails)
        {
        }

        public static implicit operator DataServiceResult<TData, TResultType>(TData data)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(data, resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(FailureResult failureResult)
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(default, resultType, failureResult.ErrorDetails);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(TResultType resultType)
        {
            return new DataServiceResult<TData, TResultType>(default, resultType);
        }
    }
}