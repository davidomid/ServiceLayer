using System;
using ServiceLayer.Internal;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class Result<TResultType> : Result, IResult<TResultType> where TResultType : struct, Enum
    {
        public Result(TResultType resultType) : base(resultType.ToResultType<ResultType>())
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

        public static implicit operator Result<TResultType>(InconclusiveResult inconclusiveResult)
        {
            return Engine.ResultFactory.Create<TResultType>(inconclusiveResult);
        }

        public static implicit operator Result<TResultType>(TResultType resultType)
        {
            return Engine.ResultFactory.Create(resultType);
        }
    }
}