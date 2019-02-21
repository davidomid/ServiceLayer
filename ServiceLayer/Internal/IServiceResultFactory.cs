using System;

namespace ServiceLayer.Internal
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
        ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(SuccessResult successResult) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(FailureResult failureResult) where TResultType : Enum;
    }
}
