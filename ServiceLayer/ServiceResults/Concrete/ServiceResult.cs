namespace ServiceLayer
{
    public class ServiceResult : GenericServiceResult<ServiceResultTypes>, IServiceResult
    {
        public ServiceResult(ServiceResultTypes resultType, params string[] errorMessages) : base(resultType, errorMessages)
        {

        }
    }
}