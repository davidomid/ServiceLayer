﻿using System;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class Result<TResultType> : Result, IResult<TResultType> where TResultType : struct, Enum
    {
        public Result(TResultType resultType) : this(resultType, default)
        {
        }

        public Result(TResultType resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public Result(TResultType resultType, object errorDetails) : base(resultType.ToResultType<ResultType>(), errorDetails)
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator Result<TResultType>(SuccessResult successResult)
        {
            return Engine.ResultFactory.Create<TResultType>(successResult);
        }

        public static implicit operator Result<TResultType>(FailureResult failureResult)
        {
            return Engine.ResultFactory.Create<TResultType>(failureResult);
        }

        public static implicit operator Result<TResultType>(TResultType resultType)
        {
            return Engine.ResultFactory.Create(resultType);
        }
    }
}