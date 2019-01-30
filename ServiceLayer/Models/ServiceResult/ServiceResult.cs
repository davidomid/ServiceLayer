namespace ServiceLayer
{
    public class ServiceResult : ServiceResult<ServiceResultTypes>, IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {
        }
    }
}