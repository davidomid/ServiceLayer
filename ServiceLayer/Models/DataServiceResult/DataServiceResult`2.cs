using System;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : DataServiceResult<TData>, IDataServiceResult<TData, TResultType> where TResultType : struct, Enum
    {
        public DataServiceResult(TData data, TResultType resultType) : this(data, resultType, default)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataServiceResult(TData data, TResultType resultType, object errorDetails) : base(data, resultType.ToResultType<ServiceResultTypes>(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator DataServiceResult<TData, TResultType>(TResultType resultType)
        {
            return ServiceResultConfiguration.DataServiceResultFactory.Create<TData, TResultType>(resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(TData data)
        {
            return ServiceResultConfiguration.DataServiceResultFactory.Create<TData, TResultType>(data);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(FailureResult failureResult)
        {
            return ServiceResultConfiguration.DataServiceResultFactory.Create<TData, TResultType>(failureResult);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(SuccessResult<TData> successResult)
        {
            return ServiceResultConfiguration.DataServiceResultFactory.Create<TData, TResultType>(successResult);
        }

        public static implicit operator DataServiceResult<TData, TResultType>(ServiceResult<TResultType> serviceResult)
        {
            return ServiceResultConfiguration.DataServiceResultFactory.Create<TData, TResultType>(serviceResult);
        }
    }
}