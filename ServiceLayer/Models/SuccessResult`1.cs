namespace ServiceLayer
{
    public class SuccessResult<TData> : DataServiceResult<TData>
    {
        public SuccessResult(TData data) : base(data, ServiceResultTypes.Success)
        {
        }

        public static implicit operator SuccessResult<TData>(TData data)
        {
            return new SuccessResult<TData>(data);
        }
    }
}
