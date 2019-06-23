﻿using System;

namespace ServiceLayer.Internal.Factories
{
    internal interface IServiceResultFactory
    {
        Result Create(ResultTypes resultType);
        Result<TResultType> Create<TResultType>(TResultType resultType) where TResultType : struct, Enum;
        Result<TResultType> Create<TResultType>(Result result) where TResultType : struct, Enum;
        Result<TResultType, TErrorType> Create<TResultType, TErrorType>(TResultType resultType, TErrorType errorDetails = default) where TResultType : struct, Enum;
        Result<TResultType, TErrorType> Create<TResultType, TErrorType>(TErrorType errorDetails = default) where TResultType : struct, Enum;
        Result<TResultType, TErrorType> Create<TResultType, TErrorType>(SuccessResult successResult) where TResultType : struct, Enum;
        Result<TResultType, TErrorType> Create<TResultType, TErrorType>(FailureResult<TErrorType> failureResult)
            where TResultType : struct, Enum;
    }
}
