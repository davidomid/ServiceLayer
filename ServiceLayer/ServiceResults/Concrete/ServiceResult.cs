namespace ServiceLayer
{
    public class ServiceResult : BaseServiceResult<ServiceResultTypes>, IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {

        }
    }
}