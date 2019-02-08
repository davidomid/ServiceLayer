using System;
using System.Linq;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : ServiceResult<TResultType>, IDataServiceResult<TData, TResultType> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType) : this(data, resultType, null)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, params object[] errorDetails) : base(resultType, errorDetails)
        {
            this.Data = data;
        }

        public TData Data { get; }

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