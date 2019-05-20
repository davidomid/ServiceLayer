namespace ServiceLayer
{
    public class SuccessResult : ServiceResult<ServiceResultTypes>
    {
        public SuccessResult() : base(ServiceResultTypes.Success)
        {
        }
    }
}
