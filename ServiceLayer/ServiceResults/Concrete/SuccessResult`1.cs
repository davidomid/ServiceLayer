namespace ServiceLayer
{
    public class SuccessResult<TData> : ServiceResult<ServiceResultTypes, TData>
    {
        public SuccessResult(TData data) : base(ServiceResultTypes.Success, data)
        {
        }
    }
}
