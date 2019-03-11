﻿using System;

namespace ServiceLayer.Internal.Factories
{
    internal interface IServiceResultFactory
    {
        ServiceResult Create(ServiceResultTypes serviceResultType);
        ServiceResult<TResultType> Create<TResultType>(TResultType resultType) where TResultType : Enum;
        ServiceResult<TResultType> Create<TResultType>(ServiceResult serviceResult) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType, TErrorType errorDetails = default) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default) where TResultType : Enum;
        ServiceResult<TResultType, TErrorType> Create<TResultType, TErrorType>(ServiceResult serviceResult, TErrorType errorDetails = default) where TResultType : Enum;
    }
}