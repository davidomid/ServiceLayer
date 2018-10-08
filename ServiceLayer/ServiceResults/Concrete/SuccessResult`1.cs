namespace ServiceLayer
{
    public class SuccessResult<TData> : ServiceResult<TData>
    {
        public SuccessResult(TData data) : base(ServiceResultTypes.Success, data)
        {
        }
    }
}
