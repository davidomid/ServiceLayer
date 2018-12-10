namespace ServiceLayer
{
    public class SuccessResult<TData> : DataServiceResult<TData>
    {
        public SuccessResult(TData data) : base(ServiceResultTypes.Success, data)
        {
        }
    }
}
