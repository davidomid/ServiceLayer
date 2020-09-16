using System;
using ServiceLayer.Internal;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class DataResult<TData, TResultType> : DataResult<TData>, IDataResult<TData, TResultType> where TResultType : struct, Enum
    {
        public DataResult(TData data, TResultType resultType) : base(data, resultType.ToResultType<ResultType>())
        {
            ResultType = resultType;
        }

        public new TResultType ResultType { get; }

        public static implicit operator DataResult<TData, TResultType>(TResultType resultType)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(resultType);
        }

        public static implicit operator DataResult<TData, TResultType>(TData data)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(data);
        }

        public static implicit operator DataResult<TData, TResultType>(FailureResult failureResult)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(failureResult);
        }

        public static implicit operator DataResult<TData, TResultType>(InconclusiveResult inconclusiveResult)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(inconclusiveResult);
        }

        public static implicit operator DataResult<TData, TResultType>(SuccessResult<TData> successResult)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(successResult);
        }

        public static implicit operator DataResult<TData, TResultType>(Result<TResultType> result)
        {
            return Engine.DataResultFactory.Create<TData, TResultType>(result);
        }
    }
}