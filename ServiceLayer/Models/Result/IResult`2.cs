﻿using System;

namespace ServiceLayer
{
    public interface IResult<out TResultType, out TErrorType> : IResult<TResultType> where TResultType : struct, Enum
    {
        TErrorType ErrorDetails { get; }
    }
}
