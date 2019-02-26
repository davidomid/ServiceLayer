using System;

namespace ServiceLayer.Internal
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
        ServiceResult<TResultType> Create<TResultType>(ServiceResultTypes serviceResultType) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(SuccessResult successResult) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(FailureResult failureResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResult serviceResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult failureResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType,
            TErrorType errorDetails) where TResultType : Enum;

        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResultTypes serviceResultType,
            TErrorType errorDetails) where TResultType : Enum;
    }
}
