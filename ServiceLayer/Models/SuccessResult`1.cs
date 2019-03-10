namespace ServiceLayer
{
    public class SuccessResult<TData> : DataServiceResult<TData, ServiceResultTypes, object>
    {
        public SuccessResult(TData data) : base(data, ServiceResultTypes.Success)
        {
        }

        public static implicit operator SuccessResult<TData>(TData data)
        {
            return SuccessResultFactory.Create(data);
        }
    }
}
