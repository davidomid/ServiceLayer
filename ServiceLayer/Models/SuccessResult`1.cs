using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class SuccessResult<TData> : DataServiceResult<TData>
    {
        public SuccessResult(TData data) : base(data, ServiceResultTypes.Success, default)
        {
        }

        public static implicit operator SuccessResult<TData>(TData data)
        {
            return Engine.SuccessResultFactory.Create(data);
        }
    }
}
