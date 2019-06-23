using System;
using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class DataResult<TData, TResultType> : DataResult<TData>, IDataResult<TData, TResultType> where TResultType : struct, Enum
    {
        public DataResult(TData data, TResultType resultType) : this(data, resultType, default)
        {
        }

        public DataResult(TData data, TResultType resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataResult(TData data, TResultType resultType, object errorDetails) : base(data, resultType.ToResultType<ResultType>(), errorDetails)
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