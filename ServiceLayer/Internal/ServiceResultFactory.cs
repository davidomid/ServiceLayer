using System;

namespace ServiceLayer.Internal
{
    internal class ServiceResultFactory : IServiceResultFactory
    {
        public ServiceResult Create(ServiceResultTypes serviceResultType)
        {
            return new ServiceResult(serviceResultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum
        {
            return new ServiceResult<TResultType>(resultType);
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResultTypes serviceResultType) where TResultType : Enum
        {
            return this.Create(serviceResultType.ToResultType<TResultType>());
        }

        public ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum
        {
            return this.Create<TResultType>(serviceResult.ResultType); 
        } 

        public ServiceResult<TResultType> Create<TResultType>(SuccessResult successResult) where TResultType : Enum
        {
            return this.Create<TResultType>((ServiceResult)successResult);
        }

        public ServiceResult<TResultType> Create<TResultType>(FailureResult failureResult) where TResultType : Enum
        {
            return this.Create<TResultType>((ServiceResult)failureResult);
        }
    }
}
