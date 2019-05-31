using System;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType, TErrorType> : DataServiceResult<TData, TResultType>, IDataServiceResult<TData, TResultType, TErrorType> where TResultType : struct, Enum
    {
        public DataServiceResult(TData data, TResultType resultType, TErrorType errorDetails) : base(data, resultType, errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TData data)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData, TResultType, TErrorType>(data);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData, TResultType, TErrorType>(failureResult);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(SuccessResult<TData> successResult)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData, TResultType, TErrorType>(successResult);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TResultType resultType)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData, TResultType, TErrorType>(resultType);
        }

        public static implicit operator DataServiceResult<TData, TResultType, TErrorType>(TErrorType errorDetails)
        {
            return ServiceLayerConfiguration.DataServiceResultFactory.Create<TData, TResultType, TErrorType>(errorDetails);
        }
    }
}