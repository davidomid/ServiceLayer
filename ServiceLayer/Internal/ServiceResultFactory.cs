using System;

namespace ServiceLayer.Internal
{
    internal class ServiceResultFactory : IServiceResultFactory
    {
        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType,
            TErrorType errorDetails = default) where TResultType : Enum
        {
            return new ServiceResult<TResultType, TErrorType>(resultType, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResultTypes serviceResultType,
            TErrorType errorDetails = default) where TResultType : Enum
        {
            return Create(serviceResultType.ToResultType<TResultType>(), errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default) where TResultType : Enum
        {
            return Create<TResultType, TErrorType>(ServiceResultTypes.Failure, errorDetails);
        }

        public ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResult serviceResult, TErrorType errorDetails = default) where TResultType : Enum
        {
            return Create<TResultType, TErrorType>(serviceResult.ResultType, errorDetails);
        }

        public ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum
        {
            return Create<TResultType, object>(resultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResultTypes serviceResultType) where TResultType : Enum
        {
            return Create<TResultType, object>(serviceResultType);
        }

        public ServiceResult Create(ServiceResultTypes serviceResultType)
        {
            return Create<ServiceResultTypes>(serviceResultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum
        {
            return Create<TResultType>(serviceResult.ResultType); 
        } 
    }
}
