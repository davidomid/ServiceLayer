using System;

namespace ServiceLayer.Internal
{
    internal class ServiceResultFactory : IServiceResultFactory
    {
        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType,
            TErrorType errorDetails) where TResultType : Enum
        {
            return new ServiceResult<TResultType, TErrorType>(resultType, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResultTypes serviceResultType,
            TErrorType errorDetails) where TResultType : Enum
        {
            return Create(serviceResultType.ToResultType<TResultType>(), errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType) where TResultType : Enum
        {
            return this.Create<TResultType, TErrorType>(resultType, default);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum
        {
            return  this.Create<TResultType, TErrorType>(ServiceResultTypes.Failure, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResult serviceResult) where TResultType : Enum
        {
            return this.Create<TResultType, TErrorType>(serviceResult.ResultType, default);
        }

        public ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum
        {
            return Create<TResultType, object>(resultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResultTypes serviceResultType) where TResultType : Enum
        {
            return this.Create(serviceResultType.ToResultType<TResultType>());
        }

        public ServiceResult Create(ServiceResultTypes serviceResultType)
        {
            return this.Create<ServiceResultTypes>(serviceResultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum
        {
            return this.Create<TResultType>(serviceResult.ResultType); 
        } 

        public ServiceResult<TResultType> Create<TResultType>(SuccessResult successResult) where TResultType : Enum
        {
            return this.Create<TResultType>((ServiceResult)successResult);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : Enum
        {
            return this.Create<TResultType, TErrorType>((ServiceResult)successResult);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult failureResult) where TResultType : Enum
        {
            return this.Create<TResultType, TErrorType>((ServiceResult)failureResult);
        }

        public ServiceResult<TResultType> Create<TResultType>(FailureResult failureResult) where TResultType : Enum
        {
            return this.Create<TResultType>((ServiceResult)failureResult);
        }
    }
}
