using System;

namespace ServiceLayer.Internal
{
    public class DataServiceResultFactory : IDataServiceResultFactory
    {
        public DataServiceResult<TData> Create<TData>(TData data)
        {
            return new SuccessResult<TData>(data);
        }

        public DataServiceResult<TData> Create<TData>(FailureResult failureResult)
        {
            return new DataServiceResult<TData>(default, ServiceResultTypes.Failure, failureResult.ErrorDetails);
        }

        public DataServiceResult<TData> Create<TData>(ServiceResultTypes resultType)
        {
            return new DataServiceResult<TData>(default, resultType);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TResultType resultType) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType>(default, resultType);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(TData data) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(data, resultType);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(FailureResult failureResult) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(default, resultType, failureResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType> Create<TData, TResultType>(SuccessResult<TData> successResult) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType>(successResult.Data, resultType, successResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TData data) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(data, resultType);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(FailureResult<TErrorType> failureResult) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, failureResult.ErrorDetails);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(SuccessResult<TData> successResult) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Success.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TResultType resultType) where TResultType : Enum
        {
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType);
        }

        public DataServiceResult<TData, TResultType, TErrorType> Create<TData, TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum
        {
            TResultType resultType = ServiceResultTypes.Failure.ToResultType<TResultType>();
            return new DataServiceResult<TData, TResultType, TErrorType>(default, resultType, errorDetails);
        }
    }
}
