using System;

namespace ServiceLayer.Internal.Factories
{
    internal class ServiceResultFactory : IServiceResultFactory
    {
        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType,
            TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return new ServiceResult<TResultType, TErrorType>(resultType, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default)
            where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(ServiceResultTypes.Failure, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(successResult.ResultType);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult<TErrorType> failureResult) where TResultType : struct, Enum
        {
            return Create<TResultType, TErrorType>(failureResult.ResultType, failureResult.ErrorDetails);
        }

        public ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : struct, Enum
        {
            return Create<TResultType, object>(resultType);
        }

        public ServiceResult Create(ServiceResultTypes serviceResultType)
        {
            return Create<ServiceResultTypes>(serviceResultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : struct, Enum
        {
            return Create<TResultType>(serviceResult.ResultType, serviceResult.ErrorDetails);
        }

        private ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(
            ServiceResultTypes serviceResultType,
            TErrorType errorDetails = default) where TResultType : struct, Enum
        {
            return Create(serviceResultType.ToResultType<TResultType>(), errorDetails);
        }

        private ServiceResult<TResultType> Create<TResultType>(ServiceResultTypes serviceResultType, object errorDetails)
            where TResultType : struct, Enum
        {
            return Create<TResultType, object>(serviceResultType, errorDetails);
        }
    }
}