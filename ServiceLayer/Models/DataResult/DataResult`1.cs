using ServiceLayer.Internal;
using ServiceLayer.Models;

namespace ServiceLayer
{
    public class DataResult<TData> : Result<ResultType, object>, IDataResult<TData>
    {
        public DataResult(TData data, ResultType resultType) : this(data, resultType, default)
        {
        }

        public DataResult(TData data, ResultType resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataResult(TData data, ResultType resultType, object errorDetails) : base(resultType, errorDetails)
        {
            Data = data;
        }

        public TData Data { get; }

        public static implicit operator DataResult<TData>(TData data)
        {
            return Engine.DataResultFactory.Create(data);
        }

        public static implicit operator DataResult<TData>(FailureResult failureResult)
        {
            return Engine.DataResultFactory.Create<TData>(failureResult);
        }

        public static implicit operator DataResult<TData>(InconclusiveResult inconclusiveResult)
        {
            return Engine.DataResultFactory.Create<TData>(inconclusiveResult);
        }

        public static implicit operator DataResult<TData>(ResultType resultType)
        {
            return Engine.DataResultFactory.Create<TData>(resultType);
        }
    }
}