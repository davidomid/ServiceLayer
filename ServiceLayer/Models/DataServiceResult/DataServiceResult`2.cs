using System;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : DataServiceResult<TData>, IDataServiceResult<TData, TResultType> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType) : this(data, resultType, null)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, object errorDetails) : base(data, resultType.ToServiceResultType(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator DataServiceResult<TData, TResultType>(TResultType resultType)
        {
            return new DataServiceResult<TData, TResultType>(default, resultType);
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

        public static implicit operator DataServiceResult<TData, TResultType>(SuccessResult<TData> successResult)
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(successResult.Data, resultType, successResult.ErrorDetails);
        }
    }
}