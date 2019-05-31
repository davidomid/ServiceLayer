using System;

namespace ServiceLayer.Internal.Factories
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
        ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : struct, Enum;
        ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : struct, Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default) where TResultType : struct, Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : struct, Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
            where TResultType : struct, Enum;
    }
}
