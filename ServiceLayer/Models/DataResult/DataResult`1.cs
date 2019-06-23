using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class DataResult<TData> : Result<ResultTypes, object>, IDataResult<TData>
    {
        public DataResult(TData data, ResultTypes resultType) : this(data, resultType, default)
        {
        }

        public DataResult(TData data, ResultTypes resultType, params object[] errorDetails) : this(data, resultType, (object)errorDetails)
        {
        }

        public DataResult(TData data, ResultTypes resultType, object errorDetails) : base(resultType, errorDetails)
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

        public static implicit operator DataResult<TData>(ResultTypes resultType)
        {
            return Engine.DataResultFactory.Create<TData>(resultType);
        }
    }
}