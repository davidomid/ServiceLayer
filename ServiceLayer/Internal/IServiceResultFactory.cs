using System;

namespace ServiceLayer.Internal
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
        ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResult serviceResult) where TResultType : Enum;
    }
}
