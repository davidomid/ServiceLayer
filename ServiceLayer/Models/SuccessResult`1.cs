using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class SuccessResult<TData> : DataResult<TData>
    {
        public SuccessResult(TData data) : base(data, ResultType.Success, default)
        {
        }

        public static implicit operator SuccessResult<TData>(TData data)
        {
            return Engine.SuccessResultFactory.Create(data);
        }
    }
}
