using System;

namespace ServiceLayer.Internal
{
    public class DataServiceResultFactory : IDataServiceResultFactory
    {
        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TResultType resultType)
            where TResultType : Enum
        {
            return Create<TData, TResultType, object>(default, resultType);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, ServiceResultTypes.Success);
        }

        public DataServiceResult<TData> Create<TData>(ServiceResultTypes resultType)
        {
            return Create<TData, ServiceResultTypes>(resultType);
        }

        public DataServiceResult<TData> Create<TData>(TData data)
        {
            return Create<TData, ServiceResultTypes>(data);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(FailureResult failureResult)
            where TResultType : Enum
        {
            return Create<TData, TResultType>(default, failureResult.ResultType, failureResult.ErrorDetails);
        }

        public DataServiceResult<TData> Create<TData>(FailureResult failureResult)
        {
            return Create<TData, ServiceResultTypes>(failureResult);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(SuccessResult<TData> successResult)
            where TResultType : Enum
        {
            return Create<TData, TResultType>(successResult.Data, successResult.ResultType, successResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data, TResultType resultType, object errorDetails = default) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, resultType, errorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data)
            where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(data, ServiceResultTypes.Success);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            SuccessResult<TData> successResult) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(successResult.Data, successResult.ResultType);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            FailureResult<TErrorType> failureResult) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, failureResult.ResultType,
                failureResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TResultType resultType) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, resultType);
        }

        public DataServiceResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, ServiceResultTypes.Failure, errorDetails);
        }

        public DataServiceResult<TData> Create<TData>(TData data, ServiceResultTypes resultType, object errorDetails = default)
        {
            return Create<TData, ServiceResultTypes>(data, resultType, errorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            TResultType resultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType, errorDetails);
        }

        private DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            ServiceResultTypes serviceResultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return Create(data, serviceResultType.ToResultType<TResultType>(), errorDetails);
        }

        private DataServiceResult<TData, TResultType, object> Create<TData, TResultType>(TData data,
            ServiceResultTypes serviceResultType, object errorDetails = default) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, serviceResultType, errorDetails);
        }
    }
}