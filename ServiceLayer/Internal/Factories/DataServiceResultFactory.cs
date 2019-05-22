using System;

namespace ServiceLayer.Internal.Factories
{
    internal class DataServiceResultFactory : IDataServiceResultFactory
    {
        // top-level
        public DataServiceResult<TData> Create<TData>(ServiceResultTypes resultType)
        {
            return Create<TData, ServiceResultTypes>(resultType);
        }

        // top-level
        public DataServiceResult<TData> Create<TData>(TData data)
        {
            return Create<TData, ServiceResultTypes>(data);
        }

        // top-level
        public DataServiceResult<TData> Create<TData>(FailureResult failureResult)
        {
            return Create<TData, ServiceResultTypes>(failureResult);
        }

        // top-level
        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(SuccessResult<TData> successResult)
            where TResultType : Enum
        {
            return Create<TData, TResultType>(successResult.Data, successResult.ResultType, successResult.ErrorDetails);
        }

        // top-level
        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data, TResultType resultType, object errorDetails = default) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, resultType, errorDetails);
        }

        // top-level
        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data)
            where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(data, ServiceResultTypes.Success);
        }

        // top-level
        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            SuccessResult<TData> successResult) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(successResult.Data, successResult.ResultType);
        }

        // top-level
        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(
            FailureResult<TErrorType> failureResult) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, failureResult.ResultType,
                failureResult.ErrorDetails);
        }

        // top-level
        public DataServiceResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, ServiceResultTypes.Failure, errorDetails);
        }

        // top-level
        public DataServiceResult<TData, TResultType, TErrorType>
            Create<TData, TResultType, TErrorType>(TResultType resultType) where TResultType : Enum
        {
            return Create<TData, TResultType, TErrorType>(default, resultType);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, ServiceResultTypes.Success);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(FailureResult failureResult)
            where TResultType : Enum
        {
            return Create<TData, TResultType>(default, failureResult.ResultType, failureResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TResultType resultType)
            where TResultType : Enum
        {
            return Create<TData, TResultType, object>(default, resultType);
        }

        private DataServiceResult<TData, TResultType, object> Create<TData, TResultType>(TData data,
            ServiceResultTypes serviceResultType, object errorDetails = default) where TResultType : Enum
        {
            return Create<TData, TResultType, object>(data, serviceResultType, errorDetails);
        }

        private DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            ServiceResultTypes serviceResultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return Create(data, serviceResultType.ToResultType<TResultType>(), errorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data,
            TResultType resultType, TErrorType errorDetails = default) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType, errorDetails);
        }
    }
}